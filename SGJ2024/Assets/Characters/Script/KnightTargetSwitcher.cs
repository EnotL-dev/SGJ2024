using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    [RequireComponent(typeof(StateBehaviour))] 
    public class KnightTargetSwitcher : MonoBehaviour
    {
        [SerializeField] private List<Health> _enemies = new List<Health>();
        private StateBehaviour _states;

        public void SwitchEnemy(Health enemy)
        {
            //_states.Target = _enemies[Random.Range(0, _enemies.Count)];
            _states.Target = enemy;
        }

        private void Awake()
        {
            _states = GetComponent<StateBehaviour>();
        }
    }
}