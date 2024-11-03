using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private StoreManager storeManager;
    private InventoryManager inventoryManager;
    [SerializeField] private Sprite activeSlot;
    [SerializeField] private Sprite disableSlot;
    [Space(10)]
    [SerializeField] private Transform parent_for_information;
    [SerializeField] private GameObject panel;
    private GameObject _panel; //Для запоминания, чтобы удалять

    [SerializeField] private AudioClip sword_sound;
    [SerializeField] private AudioClip spear_sound;
    [SerializeField] private AudioClip shield_sound;
    [SerializeField] private AudioClip potion_sound;

    private AudioSource audioSourceInventory;

    private void Awake()
    {
        try
        {
            storeManager = GameObject.FindWithTag("StoreManager").GetComponent<StoreManager>();
        } catch { }
        inventoryManager = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
        audioSourceInventory = GameObject.FindWithTag("AudioSoundInventory").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = activeSlot;
        spawnPanel();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().sprite = disableSlot;
        if(_panel != null)
        {
            Destroy(_panel);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Transform item = eventData.pointerDrag.transform;

            if ((item.gameObject.tag == "store_slot" && gameObject.tag == "inv_slot") || (item.gameObject.tag == "inv_slot" && gameObject.tag == "inv_slot") || (item.gameObject.tag == "inv_slot" && gameObject.tag == "store_slot" && gameObject.name == "SlotSell"))
            {
                Transform child = transform.GetChild(0);
                if(gameObject.name == "SlotSell")
                {
                    storeManager.sell_item(item.gameObject.GetComponent<DropAndDrag>().mySlot.gameObject.GetComponent<Image>());
                    item.gameObject.GetComponent<DropAndDrag>().canvasGroup.blocksRaycasts = true;
                    item.localPosition = Vector3.zero;
                }
                else if(item.gameObject.tag == "inv_slot" && gameObject.tag == "inv_slot")
                {
                    change_inventory_slot(item, child);
                }
                else if (item.gameObject.tag == "store_slot" && gameObject.tag == "inv_slot")
                {
                    if(!child.gameObject.activeSelf) // То есть слот пуст
                    {
                        buy_item(item, child);
                    }
                }
            }
        }
    }

    private void change_inventory_slot(Transform item, Transform child)
    {
        child.gameObject.GetComponent<DropAndDrag>().mySlot = item.gameObject.GetComponent<DropAndDrag>().mySlot;
        child.SetParent(item.gameObject.GetComponent<DropAndDrag>().mySlot);
        child.localPosition = Vector3.zero;

        item.SetParent(transform);
        item.localPosition = Vector3.zero;
        item.gameObject.GetComponent<DropAndDrag>().mySlot = transform;

        makeSound(item.gameObject.GetComponent<DropAndDrag>().id_item);

        if (_panel != null)
        {
            Destroy(_panel);
        }
    }

    public void buy_item(Transform item, Transform child) //Не забываем что мы работаем в слоте ИНВЕНТАРЯ а не магазина
    {
        ItemList itemList = ItemList.GetInstance();
        int id_item = item.gameObject.GetComponent<DropAndDrag>().id_item;
        int durability_item = itemList.returnItemById(id_item).durability;
        int cost = itemList.returnItemById(id_item).cost;
        string spriteLink = itemList.returnItemById(id_item).spriteLink;

        if (storeManager.returnMoney() >= cost)
        {
            storeManager.buying(cost);

            DoubleList doubleList = new DoubleList(id_item, durability_item);
            inventoryManager.addItem(doubleList, gameObject.GetComponent<Image>());
            child.gameObject.GetComponent<DropAndDrag>().id_item = id_item;
            child.gameObject.GetComponent<DropAndDrag>().durability_item = durability_item;
            child.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(spriteLink);
            child.gameObject.SetActive(true);

            makeSound(item.gameObject.GetComponent<DropAndDrag>().id_item);

            if (_panel != null)
            {
                Destroy(_panel);
            }

            Debug.Log($"Куплен предмет {itemList.returnItemById(id_item).name}");
        }
        else
        {
            storeManager.audioSourceStore.PlayOneShot(storeManager.buy_abort_sound);
        }
    }

    private void spawnPanel()
    {
        if (transform.GetChild(0).gameObject.activeSelf && transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().id_item > 0)
        {
            _panel = Instantiate(panel, parent_for_information);

            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parent_for_information as RectTransform,
                screenPoint,
                Camera.main,
                out Vector2 localPoint
            );

            localPoint.y += 105;
            _panel.GetComponent<RectTransform>().localPosition = localPoint;

            int id_item = transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().id_item;
            int durability_item = transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().durability_item;
            _panel.GetComponent<InformationPanelScript>().informate(id_item, durability_item);
        }
    }

    private void makeSound(int id)
    {
        if(id > 0)
        {
            if(id == 1 || id == 3 || id == 4 || id == 6 || id == 7 || id == 9 || id == 10 || id == 12)
            {
                audioSourceInventory.PlayOneShot(sword_sound);
            }
            else if (id == 2 || id == 5 || id == 8 || id == 11)
            {
                audioSourceInventory.PlayOneShot(spear_sound);
            }
            else if (id < 17)
            {
                audioSourceInventory.PlayOneShot(shield_sound);
            }
            else if (id > 16)
            {
                audioSourceInventory.PlayOneShot(potion_sound);
            }
        }
    }
}
