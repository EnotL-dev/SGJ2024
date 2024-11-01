using System.Collections;
using UnityEngine;

namespace BattleSystem
{
    public class MeleeAttack : State
    {
        private AnimationCurve _animMove;
        private float _moveTime;
        private float _maxDistance;
        private int _damage;
        private Vector3 _startPosition;

        public MeleeAttack(StateBehaviour switcher, AnimationCurve animMove, float moveTime, float maxDistance, int damage) : base(switcher)
        {
            _animMove = animMove;
            _moveTime = moveTime;
            _maxDistance = maxDistance;
            _damage = damage;   
        }

        public override void StartState()
        {
            base.StartState();
            _startPosition = _switcher.transform.position;
            _switcher.StartCoroutine(DoAttack(_switcher.Target));
        }

        private IEnumerator DoAttack(Health target)
        {
            yield return Forward((target.transform.position - _switcher.transform.position).normalized * _maxDistance + target.transform.position);
            target.TakeDamage(_damage);
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