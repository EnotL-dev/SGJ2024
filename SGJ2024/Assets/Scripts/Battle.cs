using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public class Battle : MonoBehaviour
    {
        private List<StateBehaviour> _enemies = new List<StateBehaviour>();
        [SerializeField] private StateBehaviour _knight;
        [SerializeField] private float _enemyWaiting = 2f;
        [SerializeField] private TransitionScript _darkBackGround;
        [Space]
        [SerializeField] private WarningMessage _warningMessage;
        [SerializeField] private float _warningWaitingTime = 1f;
        [Space, Tooltip("saves")]
        [SerializeField] private SaverScript _saverScript;
        [SerializeField] private PlayerCollector _playerCollector;
        [SerializeField] private KnightStats _knightStats;
        [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();
        [SerializeField] private List<StateBehaviour> _enemiesPrefabs = new List<StateBehaviour>();
        [SerializeField] private float _timeToAttack = 10f;
        [SerializeField] private float _timeToEnd = 10f;
        [SerializeField] private UnityEvent _OnVictory;
        [SerializeField] private UnityEvent _OnDefeat;
        private KnightTargetSwitcher _targetSwitcher;
        private Health _knightHealth;
        private bool _poisoning = false;
        private int _poisoningDamage = 1;
        private bool _continue = true;

        public List<Health> GetEnemiesHealths()
        {
            return _enemies.Select((x) => x.GetComponent<Health>()).ToList();
        }

        public void Poison(int damage)
        {
            _poisoning = true;
            _poisoningDamage = damage;
        }

        public void PoisonStop()
        {
            _poisoning = false;
        }

        public void Defeat()
        {
            Debug.Log("Defeat");
            _OnDefeat?.Invoke();
            _continue = false;
            _darkBackGround.gameObject.SetActive(true);
        }

        public void Victory()
        {
            Debug.Log("Victory");
            _continue = false;
            _darkBackGround.gameObject.SetActive(true);
            SaveAll();
        }

        private void SaveAll()
        {
           // _knightStats.
            _playerCollector.SaveKills();
            _saverScript.gameObject.SetActive(true);
        }

        private void Start()
        {
            if (_spawnPoints.Count == 1)
            {
                var instance = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)], transform);
                instance.transform.position = _spawnPoints[0].transform.position;
                instance.Target = _knight.GetComponent<Health>();
                _enemies.Add(instance);
            }
            else
            {
                int enemiesCount = Random.Range(3, _spawnPoints.Count);
                Shuffle(_enemiesPrefabs);
                for (var i = 0; i < enemiesCount; i++)
                {
                    var instance = Instantiate(_enemiesPrefabs[Random.Range(0, _enemiesPrefabs.Count)], transform);
                    instance.transform.position = _spawnPoints[i].transform.position;
                    instance.Target = _knight.GetComponent<Health>();
                    _enemies.Add(instance);
                }
            }
            StartCoroutine(EnemyAtacking());
            _targetSwitcher = _knight.GetComponent<KnightTargetSwitcher>();
            _knightHealth = _knight.GetComponent<Health>();
        }

        private void Shuffle<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private IEnumerator EnemyAtacking()
        {
            yield return new WaitForSeconds(_timeToAttack);
            while (_continue)
            {
                if (_enemies.FindAll((x)=>x.GetCurrentState() is Dead).Count != _enemies.Count) {
                    _warningMessage.Show();
                    yield return new WaitForSeconds(_warningWaitingTime);
                    _warningMessage.Hide();
                }
                int attackerCount = Random.Range(1, _enemies.Count + 1);
                //var attackers = _enemies.ToList();
                Shuffle(_enemies);
                int i = 0;
                while (attackerCount > 0 && i < _enemies.Count)
                {
                    if (_enemies[i].GetCurrentState() is not Dead)
                    {
                        yield return Attack(_enemies[i]);
                        i++;
                        attackerCount--;
                    }
                    else
                    {
                        _enemies.RemoveAt(i);
                    }
                }
                if (_enemies.Count == 0)
                {
                    _OnVictory?.Invoke();
                    yield return new WaitForSeconds(_timeToEnd);
                    Victory();
                    break;
                }
                _targetSwitcher.SwitchEnemy(_enemies);
                Poison();
                _warningMessage.Show();
                yield return new WaitForSeconds(_warningWaitingTime);
                _warningMessage.Hide();
                yield return Attack(_knight);
            }
        }

        private void Poison()
        {
            if (_poisoning)
                _knightHealth.TakeDamagePoison(_poisoningDamage);
        }

        private IEnumerator Attack(StateBehaviour actor)
        {
            actor.SwitchState<Attack>();
            yield return new WaitWhile(() => actor.GetCurrentState() is Idle);
            yield return new WaitForSeconds(_enemyWaiting);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Victory();
            }
        }
    }
}