using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace BattleSystem
{
    public class Health : MonoBehaviour
    {
        public int PotionArmor { get; set; } = 0;

        [SerializeField] protected int _count = 100;
        [SerializeField] protected HpBar _hpBar;
        [SerializeField] private DamageView _damageView;
        [SerializeField] private Stats _stats;
        [SerializeField] protected Animator _animator;
        [SerializeField] private UnityEvent _onHealthOver;
        [SerializeField] private AudioResource _sound;
        [SerializeField] private PlayAudioEvent _OnSound;
        protected int _currentValue;

        public int GetValue()
        {
            return _currentValue;
        }

        public void Heal(int value)
        {
            _currentValue += value;
            if (_currentValue > _count)
            {
                _currentValue = _count;
            }
            _hpBar.UpdateValue(_currentValue, _count);
            _damageView.PlayHeal(value);
        }

        public void SetCount(int value)
        {
            _count = value;
            _currentValue = value;
        }

        public virtual void TakeDamagePoison(int value)
        {
            _currentValue -= value;
            _hpBar.UpdateValue(_currentValue, _count);
            _damageView.PlayPoison(value);
            //_onHealthUpdate?.Invoke(_currentValue, _count);
            if (_currentValue <= 0)
            {
                Dead();
            }
        }

        public virtual void TakeDamage(int value)
        {
            value -= (_stats.Armor + PotionArmor);
            if (value < 0)
                value = 0;
            if (_stats is KnightStats) 
            {
                var knightStats = _stats as KnightStats;
                if (knightStats.GetItemType() == KnightStats.ItemType.shield)
                {
                    knightStats.UseItem();
                    _animator.SetTrigger("Shield");
                }
            }
            _OnSound?.Invoke(_sound);
            _currentValue -= value;
            _hpBar.UpdateValue(_currentValue, _count);
            _damageView.PlayDamage(value);
            //_onHealthUpdate?.Invoke(_currentValue, _count);
            if (_currentValue <= 0)
            {
                Dead();
            }
        }

        protected virtual void Dead()
        {
            _onHealthOver?.Invoke();
            Debug.Log("Dead");
        }

        protected virtual void Start()
        {
            _currentValue = _count;
            

        }
    }
}