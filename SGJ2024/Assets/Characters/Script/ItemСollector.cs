using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{    
    public class Item—ollector : MonoBehaviour
    {
        [System.Serializable]
        public class ItemCollectedEvent : UnityEvent<Item> { }

        [SerializeField] private ItemCollectedEvent _onCollect;

        public void Collect(Item item)
        {
            _onCollect?.Invoke(item);
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