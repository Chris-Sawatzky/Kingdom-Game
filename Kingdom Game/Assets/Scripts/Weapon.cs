using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Item
{
    public int minAttack;
    public int maxAttack;

    public Weapon(string itemName, int minAttack, int maxAttack, string spriteName, int itemCategory)//TODO get rid of itemCategory in weapon and just use itemType
    {
        this.itemName = itemName;
        this.minAttack = minAttack;
        this.maxAttack = maxAttack;
        this.spriteName = spriteName;
        this.itemCategory = itemCategory;
        itemType = "weapon";
    }
}


