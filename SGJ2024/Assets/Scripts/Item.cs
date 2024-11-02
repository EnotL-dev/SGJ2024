using System;
using UnityEngine;

[Serializable]
public class Item
{
    public int id;
    public string name;

    public int durability;
    public int cost;

    public int damage;
    public int armor;

    public int heal;

    public string spriteLink;

    public Item(int id, string name, int durability, int cost, int damage, int armor, int heal, string spriteLink)
    {
        this.id = id;
        this.name = name;
        this.durability = durability;
        this.cost = cost;
        this.damage = damage;
        this.armor = armor;
        this.heal = heal;
        this.spriteLink = spriteLink;
    }
}
