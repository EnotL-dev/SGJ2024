using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class Battle : MonoBehaviour
    {
        [SerializeField] private List<StateBehaviour> _enemies = new List<StateBehaviour>();
        [SerializeField] private StateBehaviour _knight;
        [SerializeField] private float _enemyWaiting = 2f;
        [SerializeField] private TransitionScript _darkBackGround;
        [Space]
        [SerializeField] private WarningMessage _warningMessage;
        [SerializeField] private float _warningWaitingTime = 1f;
        private KnightTargetSwitcher _targetSwitcher;
        private bool _continue = true;

        public void Defeat()
        {
            Debug.Log("Defeat");
            _continue = false;
            _darkBackGround.gameObject.SetActive(true);
        }

        public void Victory()
        {
            Debug.Log("Victory");
            _continue = false;
            _darkBackGround.gameObject.SetActive(true);
        }

        private void Start()
        {
            StartCoroutine(EnemyAtacking());
            _targetSwitcher = _knight.GetComponent<KnightTargetSwitcher>();
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
                    Victory();
                    break;
                }
                _targetSwitcher.SwitchEnemy(_enemies);
                _warningMessage.Show();
                yield return new WaitForSeconds(_warningWaitingTime);
                _warningMessage.Hide();
                yield return Attack(_knight);
            }
        }

        private IEnumerator Attack(StateBehaviour actor)
        {
            actor.SwitchState<MeleeAttack>();
            yield return new WaitWhile(() => actor.GetCurrentState() is Idle);
            yield return new WaitForSeconds(_enemyWaiting);
        }
    }
}