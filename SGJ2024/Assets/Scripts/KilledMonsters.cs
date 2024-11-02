using System;
using UnityEngine;

[Serializable]
public class KilledMonsters
{
    public int goblins;
    public int skeletons;
    public int spiders;
    public int wolfs;
    public int grifon;
    public int guardians;
    public int exodus;

    public KilledMonsters(int goblins, int skeletons, int spiders, int wolfs, int grifon, int guardians, int exodus)
    {
        this.goblins = goblins;
        this.skeletons = skeletons;
        this.spiders = spiders;
        this.wolfs = wolfs;
        this.grifon = grifon;
        this.guardians = guardians;
        this.exodus = exodus;
    }
}
