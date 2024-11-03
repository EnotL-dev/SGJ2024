using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class PlayerCollector : Item—ollector
    {
        [SerializeField] private InventoryManager _inventory;

        public bool AreFreePlaces()
        {
            var slots = _inventory.returnSlots();
            foreach (var slot in slots)
            {
                if (!slot.transform.GetChild(0).gameObject.activeInHierarchy)
                    return true;
            }
            return false;
        }

        private void PasteItem(int idItem, Image slotImage)
        {
            ItemList itemList = ItemList.GetInstance();
            Item item = itemList.returnItemById(idItem);
            int durability_item = item.durability;
            int cost = item.cost;
            string spriteLink = item.spriteLink;


            DoubleList doubleList = new DoubleList(idItem, durability_item);
            _inventory.addItem(doubleList, slotImage);
            var child = slotImage.transform.GetChild(0);
            child.gameObject.GetComponent<DropAndDrag>().id_item = idItem;
            child.gameObject.GetComponent<DropAndDrag>().durability_item = durability_item;
            child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(spriteLink);
            child.gameObject.SetActive(true);

            //makeSound(item.gameObject.GetComponent<DropAndDrag>().id_item);
        }

        public override void Collect(Item item)
        {
            var slots = _inventory.returnSlots();
            foreach (var image in slots)
            {
                if (!image.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    PasteItem(item.id, image);
                    Debug.Log("Paste");
                    break;
                }
            }
            base.Collect(item);
        }
    }
}