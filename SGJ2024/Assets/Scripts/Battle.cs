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
        private KnightTargetSwitcher _targetSwitcher;

        private void Start()
        {
            StartCoroutine(EnemyAtacking());
            _targetSwitcher = _knight.GetComponent<KnightTargetSwitcher>();
        }

        private IEnumerator EnemyAtacking()
        {
            while (true)
            {
                foreach (var enemy in _enemies)
                {
                    yield return Attack(enemy);
                }
                _targetSwitcher.SwitchEnemy();
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