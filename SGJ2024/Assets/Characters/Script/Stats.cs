using UnityEngine;

namespace BattleSystem
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private int _damage;
        [SerializeField] private int _armor;
        public int Health { get => _health.GetValue(); }
        public virtual int Damage { get => _damage; }

        public virtual int Armor { get => _armor; }
    }
}