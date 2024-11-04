using TMPro.EditorUtilities;
using UnityEngine;

namespace BattleSystem
{
    public class Bullet : MonoBehaviour
    {
       
        [SerializeField] private float _animationTime;
        private Vector3 _startPosition;
        private float _time = 0;
        private int _damage;
        protected Health _target;

        public void Launch(int damage, Health target)
        {
            _damage = damage;
            _target = target;
            if (_target == null)
            {
                Debug.LogError("Target bullet is null");
                return;
            }
            _startPosition = transform.position;
            _time = 0;
            var direction = _target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_time < _animationTime)
            {
                _time += Time.deltaTime;
                transform.position = Vector3.Lerp(_startPosition, _target.transform.position, _time / _animationTime);
            }
            else
            {
                Hit();
            }
        }

        protected virtual void Hit()
        {
            _time = 0;
            _target.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}