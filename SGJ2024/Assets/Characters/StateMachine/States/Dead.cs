using UnityEngine;

namespace BattleSystem
{
    public class Dead : State
    {
        private SpriteRenderer _sprite;
        private Animator _animator;

        public Dead(StateBehaviour switcher, SpriteRenderer sprite, Animator animator) : base(switcher)
        {
            _sprite = sprite;
            _animator = animator;
        }

        public override void StartState()
        {
            base.StartState();
            _animator.SetTrigger("Dead");
            _sprite.enabled = false;
        }
    }
}