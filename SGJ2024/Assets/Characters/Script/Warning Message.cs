using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public class WarningMessage : MonoBehaviour
    {
        public bool Active { get; set; } = false;
        [SerializeField] private GameObject _content;
        [SerializeField] private float _hideOffsetY = 5f;
        [SerializeField] private float _movingSpeed = 5f;
        private bool _isShowing = false;
        private Vector3 _startPosition;
        private Coroutine _active;
        private bool music = true;
        private bool sound = true;
        private Color _saveColor;

        public void Show()
        {
            if (_active != null)
                StopCoroutine(_active);
            _content.SetActive(true);
            _isShowing = true;
            Vector3 target = _startPosition;
            target.y += _hideOffsetY;
            _active = StartCoroutine(Move(target));
        }

        public void Hide()
        {
            if (_active != null)
                StopCoroutine(_active);
            _isShowing = false;
            _content.SetActive(false);
            transform.localPosition = _startPosition;
            //_active = StartCoroutine(Move(_startPosition, delegate { _content.SetActive(false); }));
        }

        private void Start()
        {
            _startPosition = transform.localPosition;
            _content.SetActive(false);
        }

        private IEnumerator Move(Vector3 target, UnityAction action = null)
        {
            while (Vector3.Distance(transform.localPosition, target) > 0.01f)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, target, _movingSpeed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            transform.localPosition = target;
            action?.Invoke();
        }
    }
}
