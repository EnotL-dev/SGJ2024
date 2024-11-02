using BattleSystem;
using UnityEngine;

public class KnightStats : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private StateBehaviour _states;
    private int _level = 1;
    private int _healthCount = 50;
    private int _damage = 1;

    private void Start()
    {
        _health.SetCount(_healthCount);
        _states.SetDamage(_damage);
    }
}
