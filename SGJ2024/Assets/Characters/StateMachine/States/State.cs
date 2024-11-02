using UnityEngine;

namespace BattleSystem
{
    public class State
    {
        protected StateBehaviour _switcher;

        public State(StateBehaviour switcher)
        {
            _switcher = switcher;
        }

        public virtual void DoActionsFixedUpdate() { }

        public virtual void DoActionsUpdate() { }

        public virtual void StartState() { }

        public virtual void StartStateFirst() { }

        protected virtual void Awake() { }

        public virtual void StopState()
        {

        }
    }
}