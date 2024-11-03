using UnityEngine;

namespace BattleSystem
{
    public class LyingItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        private ItemContainer _item;

        public void SetItem(ItemContainer item)
        {
            _item = item;
            _sprite.sprite = Resources.Load<Sprite>(_item.Item.spriteLink);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerCollector �ollector) && �ollector.AreFreePlaces())
            {
                �ollector.Collect(_item);
                gameObject.SetActive(false);
            }
        }
    }
}