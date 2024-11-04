using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class HealAttack : AttackType
    {
        [SerializeField] private int _healValue = 10;

        public override void DoAttack()
        {
            var enemies = _switcher.Battle.GetEnemiesHealths();
            _animator.SetTrigger("Heal");
            foreach (Health health in enemies)
            {
                if (health.GetValue() > 0)
                    health.Heal(_healValue);
            }
        }
    }
}