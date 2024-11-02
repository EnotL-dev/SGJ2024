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

        private IEnumerator EnemyAtacking()
        {
            while (_continue)
            {
                for (var i = 0; i < _enemies.Count; i++)
                {
                    if (_enemies[i].GetCurrentState() is not Dead)
                        yield return Attack(_enemies[i]);
                    else
                    {
                        _enemies.RemoveAt(i);
                        i--;
                    }
                }
                if (_enemies.Count == 0)
                {
                    Victory();
                    break;
                }

                _targetSwitcher.SwitchEnemy(_enemies[Random.Range(0, _enemies.Count)].GetComponent<Health>());
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