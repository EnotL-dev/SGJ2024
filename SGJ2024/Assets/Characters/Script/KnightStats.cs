using UnityEngine;

namespace BattleSystem
{
    public class KnightStats : Stats
    {
        public override int Damage { get => (_item != null) ? base.Damage + _item.Item.damage : base.Damage; }
        public override int Armor { get => (_item != null) ? base.Armor + _item.Item.armor : base.Armor; }
        private int _level = 1;
        private ItemContainer _item;
        [SerializeField] private ItemTrower _itemTrower;

        public enum ItemType
        {
            weapon,
            shield,
            other,
            none
        }

        public bool IsItem()
        {
            return _item != null;
        }

        public ItemType GetWeaponType()
        {
            if (!IsItem())
                return ItemType.none;
            int id = _item.Item.id;
            if (id >= 1 && id <= 12)
            {
                return ItemType.weapon;
            }
            else if (id >= 13 && id <= 16)
            {
                return ItemType.shield;
            }
            else
                return ItemType.other;
        }

        public void SetItem(ItemContainer item)
        {
            if (_item != null)
                _itemTrower.Launch(_item);
            _item = item;
        }

        public void UseItem()
        {
            if (!IsItem())
                return;

            if (!_item.UseItem())
            {
                _item = null;
                Debug.Log("Item is Broken");
            }
        }
    }
}