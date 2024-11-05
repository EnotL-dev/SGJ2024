using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace BattleSystem
{
    public class PlayerCollector : Item�ollector
    {
        [SerializeField] private InventoryManager _inventory;
        [SerializeField] private SaverScript _saver;
        private KillsContainer _killsContainer = new KillsContainer();

        public void Start()
        {
            if (_inventory != null)
                _inventory.battle = true;
        }

        public class KillsContainer
        {
            public int Goblins { get; set; }
            public int Skeletons { get; set; }
            public int Spiders { get; set; }
            public int Wolfs { get; set; }
            public int Grifon { get; set; }
            public int Guardians { get; set; }
            public int Exodus { get; set; }
        }

        public void SaveKills()
        {
            Debug.Log($"_saver {_saver.name}");
            Debug.Log($"_killsContainer {_saver.addKilledMonsters}");
            _saver.addKilledMonsters = new KilledMonsters(
                _killsContainer.Goblins,
                _killsContainer.Skeletons,
                _killsContainer.Spiders,
                _killsContainer.Wolfs,
                _killsContainer.Grifon,
                _killsContainer.Guardians,
                _killsContainer.Exodus
                );
            _saver.addKilledMonsters = new KilledMonsters(_killsContainer.Goblins, _killsContainer.Skeletons, _killsContainer.Spiders, _killsContainer.Wolfs, _killsContainer.Grifon, _killsContainer.Guardians, _killsContainer.Exodus);
        }

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

        public void InsertItemInInventory(ItemContainer item)
        {
            var slots = _inventory.returnSlots();
            bool find = false;
            foreach (var image in slots)
            {
                if (image.transform.GetChild(0).GetComponent<DropAndDrag>().id_item == 0)
                {
                    Debug.Log($"Player Send item in inventory: itemId {item.Item.id}");
                    PasteItem(item, image);
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                Debug.LogError("lOOSE ITEM");
            }
        }

        public override void Collect(ItemContainer item)
        {
            Debug.Log($"Player Collect item {item.Item.id}");
            if (item.Item.id >= 1)
            {
                InsertItemInInventory(item);
            }
            else if (item.Item.id <= -10)
            {
                Debug.Log($"Player collected item as head itemId {item.Item.id}");
                switch (item.Item.id)
                {
                    case -10:
                        _killsContainer.Exodus++;
                        break;
                    case -11:
                        _killsContainer.Goblins++;
                        break;
                    case -12:
                        _killsContainer.Grifon++;
                        break;
                    case -13:
                        _killsContainer.Guardians++;
                        break;
                    case -14:
                        _killsContainer.Skeletons++;
                        break;
                    case -15:
                        _killsContainer.Spiders++;
                        break;
                    case -16:
                        _killsContainer.Wolfs++;
                        break;
                }
            }
            base.Collect(item);
        }
    }
}