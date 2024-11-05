using UnityEngine;

namespace BattleSystem
{
    public class KnightHealth : Health
    {
        [SerializeField] private Battle _battle;

        protected override void Start()
        {
            PlayerData pl = SaveManager.LoadPlayerData();
            _currentValue = pl.hp;
            if (_currentValue > _count)
                _currentValue = _count;
            //base.Start();
        }

        protected override void Dead()
        {
            _animator.SetTrigger("Dead");
            base.Dead();
            _battle.Defeat();
        }

        public override void TakeDamage(int value)
        {
            _animator.SetTrigger("Hit");
            base.TakeDamage(value);
        }

        public override void TakeDamagePoison(int value)
        {
            _animator.SetTrigger("Hit");
            base.TakeDamagePoison(value);
        }

        public void Poison(int damage)
        {
            _battle.Poison(damage);
        }
    }
}