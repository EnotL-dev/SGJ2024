using UnityEngine;

namespace BattleSystem
{
    public abstract class AttackType : MonoBehaviour
    {
        [SerializeField] protected StateBehaviour _switcher;
        [SerializeField] protected Stats _stats;

        public abstract void DoAttack();
    }
}