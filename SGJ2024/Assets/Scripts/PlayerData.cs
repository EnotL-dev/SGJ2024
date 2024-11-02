using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int lv;
    public int money;
    public List<DoubleList> items; //первый int id, второй прочность
    public KilledMonsters killedMonsters;

    public PlayerData(int lv, int money, List<DoubleList> items, KilledMonsters killedMonsters)
    {
        this.lv = lv;
        this.money = money;
        this.items = items;
        this.killedMonsters = killedMonsters;
    }
}
