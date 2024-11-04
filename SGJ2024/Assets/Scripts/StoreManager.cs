using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [Space(20)]
    [SerializeField] private int money;
    [SerializeField] private Text money_text;
    [SerializeField] private Image[] slots;
    [Space(20)]
    [SerializeField] private KilledMonsters killedMonsters;

    public AudioClip buy_item_sound;
    public AudioClip buy_abort_sound;

    [HideInInspector] public AudioSource audioSourceStore;
    private void moneySave()
    {
        PlayerData loadedData = SaveManager.LoadPlayerData();
        PlayerData saveData = new PlayerData(loadedData.lv, loadedData.hp, loadedData.halfHp, money, loadedData.items, loadedData.killedMonsters, loadedData.dragon_was_damaged);
        SaveManager.SavePlayerData(saveData);
    }

    public int returnMoney()
    {
        return money;
    }

    public void buying(int cost)
    {
        money -= cost;
        money_text.text = $"{money}";

        audioSourceStore.PlayOneShot(buy_item_sound);
        moneySave();
    }

    private void Awake()
    {
        audioSourceStore = GameObject.FindWithTag("AudioSoundStore").GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        ItemList itemList = ItemList.GetInstance();
        for (int i = 0; i < slots.Length; i++)
        {
            Sprite sprite = Resources.Load<Sprite>(itemList.items[i].spriteLink);
            GameObject child = slots[i].transform.GetChild(0).gameObject;
            child.GetComponent<Image>().sprite = sprite;

            child.GetComponent<DropAndDrag>().id_item = itemList.items[i].id;
            child.GetComponent<DropAndDrag>().durability_item = itemList.items[i].durability;
            child.SetActive(true);
        }

        PlayerData loadedData = SaveManager.LoadPlayerData();
        money = loadedData.money;
        killedMonsters = loadedData.killedMonsters;
        money_text.text = $"{money}";
    }

    public void sell_item(Image slot)
    {
        DoubleList item = new DoubleList(0, 0);
        item.id = slot.transform.GetChild(0).GetComponent<DropAndDrag>().id_item;
        item.durability = slot.transform.GetChild(0).GetComponent<DropAndDrag>().durability_item;

        ItemList itemList = ItemList.GetInstance();
        Item sell_item = itemList.returnItemById(item.id);

        float durability_quo = 1;
        if (item.durability > 0 && sell_item.durability > 0)
        {
            durability_quo = (float)item.durability / (float)sell_item.durability;
        }

        float tempsell = ((float)sell_item.cost / 2 / durability_quo);
        money += (int)tempsell;
        money_text.text = $"{money}";

        inventoryManager.removeItem(slot);

        audioSourceStore.PlayOneShot(buy_item_sound);
        moneySave();
    }

    public void sell_kills()
    {
        if(killedMonsters != null)
        {
            int addMoney = 0;

            addMoney += killedMonsters.goblins * 25;
            addMoney += killedMonsters.skeletons * 35;
            addMoney += killedMonsters.spiders * 80;
            addMoney += killedMonsters.wolfs * 90;
            addMoney += killedMonsters.grifon * 140;
            addMoney += killedMonsters.guardians * 200;
            addMoney += killedMonsters.exodus * 240;
            killedMonsters = new KilledMonsters(0, 0, 0, 0, 0, 0, 0);

            money += addMoney;
            money_text.text = $"{money}";

            if (addMoney > 0)
            {
                audioSourceStore.PlayOneShot(buy_item_sound);
            } else { audioSourceStore.PlayOneShot(buy_abort_sound); }

            PlayerData loadedData = SaveManager.LoadPlayerData();
            PlayerData saveData = new PlayerData(loadedData.lv, loadedData.hp, loadedData.halfHp, money, loadedData.items, killedMonsters, loadedData.dragon_was_damaged);
            SaveManager.SavePlayerData(saveData);
        }
        else
        {
            audioSourceStore.PlayOneShot(buy_abort_sound);
            Debug.Log("Продать нечего.");
        }
    }
}
