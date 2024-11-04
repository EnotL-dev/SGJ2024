using UnityEngine;
using UnityEngine.Audio;

namespace BattleSystem
{
    public class ShootAttack : AttackType
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private AudioResource _sound;
        [SerializeField] private PlayAudioEvent _onSound;

        public override void DoAttack()
        {
            _bullet.transform.position = transform.position;
            _bullet.Launch(_stats.Damage, _switcher.Target);
            _animator.SetTrigger("Attack");
            _onSound?.Invoke(_sound);
        }
    }
}