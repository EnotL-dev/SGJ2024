using UnityEngine;

namespace BattleSystem
{
    public class ShootAttack : AttackType
    {
        [SerializeField] private Bullet _bullet;

        public override void DoAttack()
        {
            _bullet.transform.position = transform.position;
            _bullet.Launch(_stats.Damage, _switcher.Target);
            _animator.SetTrigger("Attack");
        }
    }
}