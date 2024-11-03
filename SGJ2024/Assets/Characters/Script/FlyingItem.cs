using UnityEngine;

namespace BattleSystem
{
    public class FlyingItem : MonoBehaviour
    {
        //[SerializeField] private float _speed = 5f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _animationTime;
        [SerializeField] private Transform _rotor;
        [SerializeField] private float _scaleIncrease = 2f;
        [SerializeField] private AnimationCurve _scaleCurve;
        [SerializeField] private SpriteRenderer _sprite;
        private Item—ollector _collector;
        private Transform _target;
        private Transform _parent;
        private Vector3 _startPosition;
        private float _time;
        private Item _item;
        //private Vector2 _position;

        public void SetItem(int itemId)
        {
            _item = ItemList.GetInstance().returnItemById(itemId);
            _sprite.sprite = Resources.Load<Sprite>(_item.spriteLink);
        }

        public void SetCollector(Item—ollector Òollector)
        {
            _collector = Òollector;
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void OnEnable()
        {
            _parent = transform.parent;
            transform.parent = null;
            _startPosition = transform.position;
            _time = 0;
        }

        private void Update()
        {
            _rotor.Rotate(transform.forward * _rotationSpeed * Time.deltaTime);
            if (_time < _animationTime)
            {
                _time += Time.deltaTime;
                transform.position = Vector3.Lerp(_startPosition, _target.position, _time / _animationTime);
                transform.localScale = Vector3.one * _scaleIncrease * _scaleCurve.Evaluate(_time / _animationTime);
            }
            else 
            {
                _time = 0;
                _collector.Collect(_item);
                gameObject.SetActive(false);
            }
        }
    }
}