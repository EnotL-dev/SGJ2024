using UnityEngine;

namespace BattleSystem
{
    public class PoisonBullet : Bullet
    {
        [SerializeField] private int _poisonDamage = 5;

        protected override void Hit()
        {
            if (_target is KnightHealth)
            {
                var health = _target as KnightHealth;
                health.Poison(_poisonDamage);
            }
            base.Hit();
        }

    }
}