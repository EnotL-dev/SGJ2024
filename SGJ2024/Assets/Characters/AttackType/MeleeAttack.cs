using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace BattleSystem
{
    [System.Serializable]
    public class PlayAudioEvent : UnityEvent<AudioResource> { }
    public class MeleeAttack : AttackType
    {
        [SerializeField] private AnimationCurve _animMove;
        [SerializeField] private float _moveTime;
        [SerializeField] private float _maxDistance;
        [SerializeField] private AudioResource _sound;
        [SerializeField] private PlayAudioEvent _OnAttack;
        private Vector3 _startPosition;

        public override void DoAttack()
        {
            _startPosition = _switcher.transform.position;
            _switcher.StartCoroutine(DoAttack(_switcher.Target));
        }

        private IEnumerator DoAttack(Health target)
        {
            _animator.SetTrigger("Attack");
            _OnAttack?.Invoke(_sound);
            yield return Forward((target.transform.position - _switcher.transform.position).normalized * _maxDistance + target.transform.position);
            target.TakeDamage(_stats.Damage);
            yield return Backward();
        }

        private IEnumerator Forward(Vector3 target)
        {
            float time = 0;
            while (time < _moveTime)
            {
                time += Time.deltaTime;
                _switcher.transform.position = Vector3.Lerp(_startPosition, target, _animMove.Evaluate(time / _moveTime));
                yield return new WaitForEndOfFrame();
            }
        }

        private IEnumerator Backward()
        {
            Vector3 _currentPosition = _switcher.transform.position;
            float time = 0;
            while (time < _moveTime)
            {
                time += Time.deltaTime;
                _switcher.transform.position = Vector3.Lerp(_currentPosition, _startPosition, _animMove.Evaluate(time / _moveTime));
                yield return new WaitForEndOfFrame();
            }
        }
    }
}