using UnityEngine;

namespace BattleSystem
{
    public class KnightStats : Stats
    {
        public override int Damage { get => (_item != null) ? base.Damage + _item.damage : base.Damage; }
        public override int Armor { get => (_item != null) ? base.Armor + _item.armor : base.Armor; }
        private int _level = 1;
        private Item _item;
        [SerializeField] private ItemTrower _itemTrower;

        public void SetItem(Item item)
        {
            if (_item != null)
                _itemTrower.Launch(_item.id);
            _item = item;
        }
    }
}