using System;
using System.Collections.Generic;
using UnityEngine;

public class SaverScript : MonoBehaviour
{
    [Header("��������� �� ������ ������ �� ��������� �������.\n ���� ���� ���, �������� �� ��� ���.")]
    public int add_lv;
    public int add_money;
    [SerializeField] public List<DoubleList> items = new List<DoubleList>();
    public KilledMonsters addKilledMonsters = new KilledMonsters(0, 0, 0, 0, 0, 0, 0);

    private void OnEnable()
    {
        int temp_lv = add_lv;
        int temp_money = add_money;
        List<DoubleList> temp_items = new List<DoubleList>();
        KilledMonsters temp_addLilledMonsters = new KilledMonsters(0,0,0,0,0,0,0);

        PlayerData loadedData = SaveManager.LoadPlayerData();
        if (loadedData != null)
        {
            temp_lv += loadedData.lv;
            temp_money += loadedData.money;
            temp_items = loadedData.items;
            temp_addLilledMonsters = loadedData.killedMonsters;
        }

        if(items.Count > 0)
        {
            temp_items = items;
        }
        temp_addLilledMonsters = addKills(temp_addLilledMonsters, addKilledMonsters);

        PlayerData playerData = new PlayerData(temp_lv, temp_money, temp_items, temp_addLilledMonsters);
        SaveManager.SavePlayerData(playerData);

        PlayerData _loadedData = SaveManager.LoadPlayerData();
        if (loadedData != null)
        {
            Debug.Log($"�������: {_loadedData.lv}, ������: {_loadedData.money}, ���������: {_loadedData.items.Count}, ��������: {_loadedData.killedMonsters.goblins}");
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