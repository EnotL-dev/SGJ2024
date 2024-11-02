using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{
    public class Item—ollector : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onCollect;

        public void Collect(FlyingItem item)
        {
            _onCollect?.Invoke();
            Debug.Log("Collected");
        }

        //private void OnTriggerEnter2D(Collider2D other)
        //{
        //    if (other.TryGetComponent(out FlyingItem item))
        //    {
        //        item.gameObject.SetActive(false);
        //    }
        //}
    }
}