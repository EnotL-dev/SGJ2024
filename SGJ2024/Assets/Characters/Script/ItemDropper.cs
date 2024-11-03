using System.Collections.Generic;
using UnityEngine;

namespace BattleSystem
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private FlyingItem _flyingItem;
        [SerializeField] private List<Item—ollector> _lyingItem = new List<Item—ollector>();
        [SerializeField] private int _itemId = 1;

        public void Drop()
        {
            int selected = Random.Range(0, _lyingItem.Count);
            DropOn(new ItemContainer(_itemId, ItemList.GetInstance().returnItemById(_itemId).durability), _lyingItem[selected]);
        }

        public void DropOn(ItemContainer item, Item—ollector target)
        {
            _flyingItem.SetTarget(target.transform);
            _flyingItem.SetCollector(target);
            _flyingItem.SetItem(item);
            _flyingItem.gameObject.SetActive(true);
        }
    }
}