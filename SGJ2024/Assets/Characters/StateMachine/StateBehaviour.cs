using System.Linq;
using UnityEngine;

namespace BattleSystem
{
    public class StateBehaviour : MonoBehaviour
    {
        public Health Target { get 
            {
                if (_target == null)
                    Debug.LogError("StateBehaviour: Target is null");
                return _target;
                        }
            set { _target = value; } }
        [SerializeField] private Health _target;
        [Space, Tooltip("Attack")]
        [SerializeField] private AttackType _attackType;
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private Animator _animator;
        protected State[] _states;
        protected State _currentState;

        public void SetDeadState()
        {
            SwitchState<Dead>();
        }

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
                new Attack(this, _attackType),
                new Idle(this, _animator),
                new Dead(this, _sprite, _animator),
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