using UnityEngine;

namespace BattleSystem
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] public Health _health;
        [SerializeField] private int _damage;
        [SerializeField] private int _armor;
        public virtual Health Health { get => _health; }
        public virtual int Damage { get => _damage; }

        public virtual int Armor { get => _armor; }
    }
}