using System;
using System.Collections.Generic;
using UnityEngine;

public class SaverScript : MonoBehaviour
{
    [Header("ÑÎÕĞÀÍßÅÒ ÍÅ ÏÓÑÒÛÅ ÊËÀÑÑÛ ÏÎ ÀÊÒÈÂÀÖÈÈ ÎÁÚÅÊÒÀ.\n Åñëè äàòû íåò, ñîõğàíèò òî ÷òî òóò.")]
    public int add_lv;
    [SerializeField] private bool dontChangeHp = false;
    public int hp = 100;
    public bool halfHp = false;
    public int add_money;
    [SerializeField] public List<DoubleList> items = new List<DoubleList>();
    [SerializeField] private bool removeKills = false;
    public KilledMonsters addKilledMonsters = new KilledMonsters(0, 0, 0, 0, 0, 0, 0);
    public bool dragon_was_damaged = false;

    private void OnEnable()
    {
        int temp_lv = add_lv;
        int temp_hp = 1;
        int temp_money = add_money;
        List<DoubleList> temp_items = new List<DoubleList>();
        KilledMonsters temp_addLilledMonsters = new KilledMonsters(0,0,0,0,0,0,0);

        PlayerData loadedData = SaveManager.LoadPlayerData();
        if (loadedData != null)
        {
            temp_lv += loadedData.lv;
            temp_hp = loadedData.hp;
            temp_money += loadedData.money;
            temp_items = loadedData.items;
            temp_addLilledMonsters = loadedData.killedMonsters;
        }

        if(items.Count > 0)
        {
            temp_items = items;
        }

        if(dontChangeHp)
        {
            temp_hp = hp;
        }

        if (!removeKills)
        {
            temp_addLilledMonsters = addKills(temp_addLilledMonsters, addKilledMonsters);
        }
        else
        {
            temp_addLilledMonsters = new KilledMonsters(0, 0, 0, 0, 0, 0, 0);
        }

        PlayerData playerData = new PlayerData(temp_lv, temp_hp, halfHp, temp_money, temp_items, temp_addLilledMonsters, dragon_was_damaged);
        SaveManager.SavePlayerData(playerData);

        PlayerData _loadedData = SaveManager.LoadPlayerData();
        if (loadedData != null)
        {
            Debug.Log($"Óğîâåíü: {_loadedData.lv}, ÕÏ ñåé÷àñ: {_loadedData.hp}, Äåíüãè: {_loadedData.money}, Ïğåäìåòîâ: {_loadedData.items.Count}, Ìîíñòğîâ: {_loadedData.killedMonsters.goblins}");
        }
    }

    private KilledMonsters addKills(KilledMonsters data_a, KilledMonsters data_b)
    {
        data_a.goblins += data_b.goblins;
        data_a.skeletons += data_b.skeletons;
        data_a.spiders += data_b.spiders;
        data_a.wolfs += data_b.wolfs;
        data_a.grifon += data_b.grifon;
        data_a.guardians += data_b.guardians;
        data_a.exodus += data_b.exodus;

        return data_a;
    }
}
