using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class MeleeAttack : AttackType
    {
        [SerializeField] private AnimationCurve _animMove;
        [SerializeField] private float _moveTime;
        [SerializeField] private float _maxDistance;
        private Vector3 _startPosition;

        public override void DoAttack()
        {
            _startPosition = _switcher.transform.position;
            _switcher.StartCoroutine(DoAttack(_switcher.Target));
        }

        private IEnumerator DoAttack(Health target)
        {
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