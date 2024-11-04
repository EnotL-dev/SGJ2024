using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace BattleSystem
{
    public class HealAttack : AttackType
    {
        [SerializeField] private int _healValue = 10;
        [SerializeField] private AudioResource _sound;
        [SerializeField] private PlayAudioEvent _onSound;

        public override void DoAttack()
        {
            var enemies = _switcher.Battle.GetEnemiesHealths();
            _animator.SetTrigger("Heal");
            _onSound?.Invoke(_sound);
            foreach (Health health in enemies)
            {
                if (health.GetValue() > 0)
                    health.Heal(_healValue);
            }
        }
    }
}