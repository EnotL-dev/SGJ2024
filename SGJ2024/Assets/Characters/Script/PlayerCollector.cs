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

        private void PasteItem(ItemContainer itemContainer, Image slotImage)
        {
            ItemList itemList = ItemList.GetInstance();
            DoubleList doubleList = new DoubleList(itemContainer.Item.id, itemContainer.Durability);
            _inventory.addItem(doubleList, slotImage);
            var child = slotImage.transform.GetChild(0);
            child.gameObject.GetComponent<DropAndDrag>().id_item = itemContainer.Item.id;
            child.gameObject.GetComponent<DropAndDrag>().durability_item = itemContainer.Durability;
            child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(itemContainer.Item.spriteLink);
            child.gameObject.SetActive(true);

            //makeSound(item.gameObject.GetComponent<DropAndDrag>().id_item);
        }

        public override void Collect(ItemContainer item)
        {
            var slots = _inventory.returnSlots();
            foreach (var image in slots)
            {
                if (!image.transform.GetChild(0).gameObject.activeInHierarchy)
                {
                    PasteItem(item, image);
                    Debug.Log("Paste");
                    break;
                }
            }
            base.Collect(item);
        }
    }
}