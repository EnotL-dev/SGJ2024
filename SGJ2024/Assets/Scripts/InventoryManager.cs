using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Image[] slots;
    [Space(20)]
    [SerializeField] private List<DoubleList> items;

    private void OnEnable()
    {
        PlayerData loadedData = SaveManager.LoadPlayerData();
        items = loadedData.items;
        loadItems();
    }

    private void OnDisable()
    {
        saveItems();
    }

    private int return_slot_num(Image slot_num)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(slots[i] == slot_num)
            {
                return i;
            }
        }

        return -1;
    }

    public void addItem(DoubleList doubleList, Image slot)
    {
        int slot_num = return_slot_num(slot);
        if(slots[slot_num].sprite != null && slot_num >= 0) //Вторая проверка (допустим?)
        {
            items[slot_num] = doubleList;
        }
        else
        {
            Debug.Log("НЕВОЗМОЖНО!");
        }
    }

    public void removeItem(Image slot)
    {
        int slot_num = return_slot_num(slot);
        if (slots[slot_num].sprite != null && slot_num >= 0) //Вторая проверка (допустим?)
        {
            items[slot_num] = new DoubleList(0,0);

            slots[slot_num].transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().id_item = 0;
            slots[slot_num].transform.GetChild(0).gameObject.GetComponent<DropAndDrag>().durability_item = 0;
            slots[slot_num].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    private void loadItems()
    {
        foreach (Image slot in slots)
        {
            GameObject child = slot.transform.GetChild(0).gameObject;
            child.SetActive(false);
        }

        
        ItemList itemList = ItemList.GetInstance();
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].id != 0)
            {
                Sprite sprite = Resources.Load<Sprite>(itemList.items[items[i].id - 1].spriteLink);
                GameObject child = slots[i].transform.GetChild(0).gameObject;
                child.GetComponent<Image>().sprite = sprite;
                child.GetComponent<DropAndDrag>().id_item = items[i].id;
                child.GetComponent<DropAndDrag>().durability_item = items[i].durability;
                child.SetActive(true);
            }
        }
    }

    private void saveItems()
    {
        int temp_lv = 0;
        int temp_money = 0;
        KilledMonsters temp_addLilledMonsters = new KilledMonsters(0, 0, 0, 0, 0, 0, 0);

        PlayerData loadedData = SaveManager.LoadPlayerData();
        if (loadedData != null)
        {
            temp_lv += loadedData.lv;
            temp_money += loadedData.money;
            temp_addLilledMonsters = loadedData.killedMonsters;
        }

        List<DoubleList> temp_items = new List<DoubleList>();

        foreach(Image slot in slots)
        {
            DropAndDrag item_in_slot = slot.transform.GetChild(0).gameObject.GetComponent<DropAndDrag>();
            temp_items.Add(new DoubleList(item_in_slot.id_item, item_in_slot.durability_item));
        }

        PlayerData playerData = new PlayerData(temp_lv, temp_money, temp_items, temp_addLilledMonsters);
        SaveManager.SavePlayerData(playerData);
    }
}
