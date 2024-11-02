using UnityEngine;

namespace BattleSystem
{
    public class Dead : State
    {
        private SpriteRenderer _sprite;

        public Dead(StateBehaviour switcher, SpriteRenderer sprite) : base(switcher)
        {
            _sprite = sprite;
        }

        public override void StartState()
        {
            base.StartState();
            _sprite.enabled = false;
        }
    }
}