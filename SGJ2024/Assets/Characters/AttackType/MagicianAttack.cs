using UnityEngine;

namespace BattleSystem
{
    public class MagicianAttack : AttackType
    {
        [SerializeField] private AttackType _healAttack;
        [SerializeField] private AttackType _shoot;

        public override void DoAttack()
        {
            if (Random.Range(0, 101) >= 25)
            {
                _shoot.DoAttack();
            }
            else 
            {
                _shoot.DoAttack();
            }
        }
    }
}