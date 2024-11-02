using UnityEngine;

namespace BattleSystem
{
    public class ItemDropper : MonoBehaviour
    {
        [SerializeField] private FlyingItem _flyingItem;
        [SerializeField] private Item—ollector _lyingItem;

        public void Drop()
        {
            _flyingItem.SetTarget(_lyingItem.transform);
            _flyingItem.SetCollector(_lyingItem);
            _flyingItem.gameObject.SetActive(true);
        }

    }
}