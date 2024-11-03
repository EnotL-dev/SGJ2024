using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class ItemTrower : MonoBehaviour
    {
        [SerializeField] private FlyingItem _prefab;
        [SerializeField] private float _poolSize = 5f;
        [SerializeField] private Transform _target;
        [SerializeField] private Item—ollector _collector;
        [SerializeField] private float _reload = 0.5f;
        private float _reloadTime = 0;
        private bool _isReloading = false;
        private List<FlyingItem> _pool = new List<FlyingItem>();
        private int _poolIndex = 0;

        public void Launch(int itemId)
        {
            if (_isReloading)
                return;
            LaunchItem(_pool[_poolIndex], itemId);
            _poolIndex++;
            if (_poolIndex > _pool.Count - 1)
            {
                _poolIndex = 0;
            }
            _isReloading = true;
        }

        private void Start()
        {
            for (var i = 0; i < _poolSize; i++)
            {
                var instance = Instantiate(_prefab, transform);
                instance.gameObject.SetActive(false);
                _pool.Add(instance);
                instance.SetCollector(_collector);
            }
        }

        private void LaunchItem(FlyingItem item, int itemId)
        {
            item.transform.position = transform.position;
            item.SetTarget(_target);
            item.SetItem(itemId);
            item.gameObject.SetActive(true);
            // bullet.transform.parent = null;
            var direction = _target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // bullet.transform.parent = null;
            item.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void Update()
        {
            //if (!_isReloading)
            //{
            //    LaunchItem(_pool[_poolIndex]);
            //    _poolIndex++;
            //    if (_poolIndex > _pool.Count - 1)
            //    {
            //        _poolIndex = 0;
            //    }
            //    _isReloading = true;
            //}
            /*else*/ if (_isReloading)
            {
                if (_reloadTime < _reload)
                    _reloadTime += Time.deltaTime;
                else
                {
                    _reloadTime = 0;
                    _isReloading = false;
                }
            }
        }
    }
}