using BattleSystem;
using UnityEngine;

public class KnightStats : Stats
{
    public override int Damage { get => (_item != null) ? base.Damage + _item.damage : base.Damage; }
    private int _level = 1;
    private Item _item;

    public void SetItem(Item item)
    {
        _item = item;
    }
}
