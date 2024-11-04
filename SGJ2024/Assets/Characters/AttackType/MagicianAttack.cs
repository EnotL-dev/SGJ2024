using UnityEngine;

namespace BattleSystem
{
    public class MagicianAttack : AttackType
    {
        [SerializeField] private HealAttack _healAttack;
        [SerializeField] private ShootAttack _shoot;

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