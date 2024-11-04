using UnityEngine;

namespace BattleSystem
{
    public abstract class AttackType : MonoBehaviour
    {
        [SerializeField] protected StateBehaviour _switcher;
        [SerializeField] protected Stats _stats;
        [SerializeField] protected Animator _animator;

        public abstract void DoAttack();
    }
}