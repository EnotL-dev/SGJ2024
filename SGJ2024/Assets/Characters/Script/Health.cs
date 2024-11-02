using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField] protected int _count = 100;
        [SerializeField] private HpBar _hpBar;
        [SerializeField] private UnityEvent _onHealthOver;
        protected int _currentValue;

        public int GetValue()
        {
            return _currentValue;
        }

        public void SetCount(int value)
        {
            _count = value;
            _currentValue = value;
        }

        public virtual void TakeDamage(int value)
        {
            _currentValue -= value;
            _hpBar.UpdateValue(_currentValue, _count);
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

        private void Start()
        {
            _currentValue = _count;
        }
    }
}