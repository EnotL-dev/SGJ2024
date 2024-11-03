using System.Linq;
using UnityEngine;

namespace BattleSystem
{
    public class StateBehaviour : MonoBehaviour
    {
        public Health Target { get => _target; set { _target = value; } }
        [SerializeField] private Health _target;
        [Space, Tooltip("Attack")]
        [SerializeField] private AnimationCurve _animMove;
        [SerializeField] private float _moveTime = 1f;
        [SerializeField] private float _maxDistance = 1f;
        [SerializeField] private Stats _stats;
        [SerializeField] private SpriteRenderer _sprite;
        protected State[] _states;
        protected State _currentState;

        public void SetDeadState()
        {
            SwitchState<Dead>();
        }

        //public void SetDamage(int value)
        //{
        //    _damage = value;
        //}

        public State GetCurrentState()
        {
            return _currentState;
        }

        public void SwitchState<T>() where T : State
        {
            var newState = _states.FirstOrDefault(s => s is T);
            if (newState == null)
            {
                Debug.LogError("State not found!");
                return;
            }
            if (_currentState != null)
                _currentState.StopState();
            newState.StartState();
            _currentState = newState;
        }

        private void SwitchStateFirst(int index)
        {
            var newState = _states[index];
            newState.StartStateFirst();
            _currentState = newState;
        }

        private void Awake()
        {
            _states = new State[3]
            {
                new MeleeAttack(this, _animMove, _moveTime, _maxDistance, _stats.Damage),
                new Idle(this),
                new Dead(this, _sprite),
            };
            SwitchState<Idle>();
        }

        private void Update()
        {
            _currentState.DoActionsUpdate();
        }

        private void FixedUpdate()
        {
            _currentState.DoActionsFixedUpdate();
        }
    }
}