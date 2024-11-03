using UnityEngine;
using UnityEngine.Events;

namespace BattleSystem
{    
    public class Item—ollector : MonoBehaviour
    {
        [System.Serializable]
        public class ItemCollectedEvent : UnityEvent<ItemContainer> { }

        [SerializeField] private ItemCollectedEvent _onCollect;

        public virtual void Collect(ItemContainer item)
        {
            _onCollect?.Invoke(item);
        }
    }
}