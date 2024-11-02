using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    [RequireComponent(typeof(StateBehaviour))] 
    public class KnightTargetSwitcher : MonoBehaviour
    {
        private StateBehaviour _states;

        public void SwitchEnemy(List<StateBehaviour> enemies)
        {
            //_states.Target = _enemies[Random.Range(0, _enemies.Count)];
            int min = int.MaxValue;
            Health minEnemy = null;
            foreach (StateBehaviour enemy in enemies)
            {
                if (enemy.TryGetComponent(out Health health) && health.GetValue() < min && enemy.GetCurrentState() is not Dead)
                {
                    minEnemy = health;
                    min = health.GetValue();
                }
            }
            _states.Target = minEnemy;
        }

        private void Awake()
        {
            _states = GetComponent<StateBehaviour>();
        }
    }
}