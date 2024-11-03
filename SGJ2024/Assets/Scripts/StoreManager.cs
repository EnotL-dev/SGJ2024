using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private int money;
    [SerializeField] private Text money_text;
    [SerializeField] private Image[] slots;
    [Space(20)]
    [SerializeField] private KilledMonsters killedMonsters;

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
        money_text.text = $"Кошелек\n{money}";
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

            money += addMoney;
            money_text.text = $"Кошелек\n{money}";
        }
        else
        {
            Debug.Log("Продать нечего.");
        }
    }
}
