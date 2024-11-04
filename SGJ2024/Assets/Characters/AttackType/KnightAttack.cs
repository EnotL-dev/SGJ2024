using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace BattleSystem
{
    public class KnightAttack : AttackType
    {
        [SerializeField] private AnimationCurve _animMove;
        [SerializeField] private float _moveTime;
        [SerializeField] private float _maxDistance;
        [SerializeField] private Battle _battle;
        [SerializeField] private AudioResource _sound;
        [SerializeField] private PlayAudioEvent _onSound;
        private Vector3 _startPosition;

        public override void DoAttack()
        {
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
                DoAttack(_battle.GetEnemiesHealths(), knightStats);
            }
            else
                _switcher.StartCoroutine(DoAttack(_switcher.Target, knightStats, weapon));
        }

        private void DoAttack(List<Health> targets, KnightStats knightStats)
        {
            _onSound?.Invoke(_sound);
            foreach (Health target in targets)
            {
                target.TakeDamage(_stats.Damage);
            }
            _animator.SetTrigger("Attack");
            knightStats.UseItem();
        }

        private IEnumerator DoAttack(Health target, KnightStats knightStats, bool weapon)
        {
            _animator.SetTrigger("Attack");
            _onSound?.Invoke(_sound);
            yield return Forward((target.transform.position - _switcher.transform.position).normalized * _maxDistance + target.transform.position);
            target.TakeDamage(_stats.Damage);
            if (weapon)
            {
                knightStats.UseItem();
            }
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