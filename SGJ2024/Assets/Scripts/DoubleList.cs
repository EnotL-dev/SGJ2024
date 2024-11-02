using System;
using UnityEngine;

[Serializable]
public class DoubleList
{
    public int id;
    public int durability;
    public DoubleList(int id, int durability)
    {
        this.id = id;
        this.durability = durability;
    }
}
