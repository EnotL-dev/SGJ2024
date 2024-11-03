using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class MeleeAttack : State
    {
        private AnimationCurve _animMove;
        private float _moveTime;
        private float _maxDistance;
        private Stats _stats;
        private Vector3 _startPosition;

        public MeleeAttack(StateBehaviour switcher, AnimationCurve animMove, float moveTime, float maxDistance, Stats stats) : base(switcher)
        {
            _animMove = animMove;
            _moveTime = moveTime;
            _maxDistance = maxDistance;
            _stats = stats;   
        }

        public override void StartState()
        {
            base.StartState();
            _startPosition = _switcher.transform.position;

            bool weapon = false;
            bool axe = false;
            KnightStats knightStats = null;
            if (_stats is KnightStats)
            {
                knightStats = _stats as KnightStats;
                if (knightStats.GetItemType() == KnightStats.ItemType.weapon)
                {
                    weapon = true;
                    axe = knightStats.ItemIsAxe();
                }
            }
            if (weapon && axe)
            {
                DoAttack(_switcher.GetAllEnemiyes(), knightStats);
            }
            else
                _switcher.StartCoroutine(DoAttack(_switcher.Target, knightStats, weapon));
        }

        private void DoAttack(List<Health> targets, KnightStats knightStats)
        {
            foreach (Health target in targets)
            {
                target.TakeDamage(_stats.Damage);
            }
            knightStats.UseItem();
        }

        private IEnumerator DoAttack(Health target, KnightStats knightStats, bool weapon)
        {
            yield return Forward((target.transform.position - _switcher.transform.position).normalized * _maxDistance + target.transform.position);
            target.TakeDamage(_stats.Damage);
            if (weapon)
                knightStats.UseItem();
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