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
            bool halfHp = pl.halfHp;
            int max_count = _count + (pl.lv*40);
            
            if (halfHp)
            {
                max_count /= 2;
            }

            if (_currentValue > max_count)
            {
                _currentValue = max_count;
            }

            _count = max_count;
            _hpBar.UpdateValue(_currentValue, max_count);

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