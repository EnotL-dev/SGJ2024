using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{    
    public class Item—ollector : MonoBehaviour
    {
        [System.Serializable]
        public class ItemCollectedEvent : UnityEvent<Item> { }

        [SerializeField] private ItemCollectedEvent _onCollect;

        public virtual void Collect(Item item)
        {
            _onCollect?.Invoke(item);
            Debug.Log("Collected");
        }
    }
}