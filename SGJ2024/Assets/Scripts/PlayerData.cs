using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int lv;
    public int hp;
    public bool halfHp; // ���� true, ������ � ������ ������������ �� � ��� ����� ������
    public int money;
    public List<DoubleList> items; //������ int id, ������ ���������
    public KilledMonsters killedMonsters;
    public bool dragon_was_damaged;

    public PlayerData(int lv, int hp, bool halfHp, int money, List<DoubleList> items, KilledMonsters killedMonsters, bool dragon_was_damaged)
    {
        this.lv = lv;
        this.hp = hp;
        this.halfHp = halfHp;
        this.money = money;
        this.items = items;
        this.killedMonsters = killedMonsters;
        this.dragon_was_damaged = dragon_was_damaged;
    }
}
