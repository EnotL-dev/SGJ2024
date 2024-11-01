using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public class Health : MonoBehaviour
    {
        [System.Serializable]
        public class TwoIntEvent : UnityEvent<int, int> { }

        [SerializeField] private int _count = 100;
        [SerializeField] private UnityEvent _onHealthOver;
        [SerializeField] private TwoIntEvent _onHealthUpdate;
        private int _currentValue;

        public void TakeDamage(int value)
        {
            _currentValue -= value;
            _onHealthUpdate?.Invoke(_currentValue, _count);
            if (value <= 0)
            {
                _onHealthOver?.Invoke();
            }
        }

        private void Start()
        {
            _currentValue = _count;
        }
    }
}