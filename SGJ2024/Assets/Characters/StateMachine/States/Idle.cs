using UnityEngine;

namespace BattleSystem
{
    public class Idle : State
    {
        [SerializeField] private Animator _animator;

        public Idle(StateBehaviour switcher, Animator animator) : base(switcher)
        {
            _animator = animator;
        }

        public override void StartState()
        {
            base.StartState();
          //  _animator.SetTrigger("Idle");
        }
    }
}