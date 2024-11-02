using UnityEngine;

namespace BattleSystem
{
    public class KnightHealth : Health
    {
        [SerializeField] private Battle _battle;

        protected override void Dead()
        {
            base.Dead();
            _battle.Defeat();
        }
    }
}