using UnityEngine;

namespace BattleSystem
{
    public class LyingItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        
        private Item _item;

        public void SetItem(Item item)
        {
            _item = item;
            _sprite.sprite = Resources.Load<Sprite>(_item.spriteLink);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out PlayerCollector ñollector) && ñollector.AreFreePlaces())
            {
                ñollector.Collect(_item);
                gameObject.SetActive(false);
            }
        }
    }
}