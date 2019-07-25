using System;
using System.Collections.Generic;

[System.Serializable]

public class KingdomData
{
    public string name;
    public int gold = 0;
    public int wood = 0;
    public int stone = 0;
    public int blacksmithLevel = 0;
    public int bsUpgradeCost = 0;
    public int completedRegions = 0;

    public List<Weapon> weapons = new List<Weapon>();
    public List<Armor> armor = new List<Armor>();
    public List<Hero> heroes = new List<Hero>();
}