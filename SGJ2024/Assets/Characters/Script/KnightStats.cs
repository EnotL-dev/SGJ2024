using UnityEngine;

namespace BattleSystem
{
    public class KnightStats : Stats
    {
        public override int Damage { get => (_item != null) ? base.Damage + _item.Item.damage + _potionDamage : base.Damage + _potionDamage; }
        public override int Armor { get => (_item != null) ? base.Armor + _item.Item.armor : base.Armor; }
        private int _level = 1;
        private int _potionDamage = 0;
        private ItemContainer _item = null;
        [SerializeField] private ItemTrower _itemTrower;
        [SerializeField] private Battle _battle;

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

        public ItemType GetItemType()
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

        public ItemType GetItemType(int itemId)
        {
            if (itemId >= 1 && itemId <= 12)
            {
                return ItemType.weapon;
            }
            else if (itemId >= 13 && itemId <= 16)
            {
                return ItemType.shield;
            }
            else
                return ItemType.other;
        }

        public bool ItemIsAxe()
        {
            int id = _item.Item.id;
            if (id == 3 || id == 6 || id == 9 || id == 12)
                return true;
            return false;
        }

        public void SetItem(ItemContainer item)
        {
            Debug.Log($"id {item.Item.id} | type {GetItemType(item.Item.id)}");
            if (GetItemType(item.Item.id) == ItemType.other) // Зелья, пиво и тд
            {   
                if (item.Item.id >= 17 && item.Item.id <= 20) // Лечение
                {
                    Health.Heal(item.Item.heal);
                }
                else
                {
                    switch (item.Item.id)
                    {
                        case 21:
                            Health.PotionArmor += 5;
                            break;
                        case 22:
                            _potionDamage += 6;
                            break;
                        case 23:
                            _battle.PoisonStop();
                            break;
                    }
                }
            }
            else
            {
                if (_item != null)
                    _itemTrower.Launch(_item);
                _item = item;
            }
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