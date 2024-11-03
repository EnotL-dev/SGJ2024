using System;

namespace BattleSystem
{
    [Serializable]
    public class ItemContainer 
    {
        public Item Item { get; private set; }
        public int Durability { get; private set; }

        public ItemContainer(int itemId, int durability) 
        {
            Item = ItemList.GetInstance().returnItemById(itemId);
            Durability = durability;
        }

        public bool UseItem()
        {
            Durability--;
            if (Durability <= 0)
                return false;
            return true;
        }
    }
}