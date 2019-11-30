using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon : Item
{
    public int minAttack;
    public int maxAttack;

    public Weapon(string itemName, int minAttack, int maxAttack, string spriteName, int itemCategory)
    {
        this.itemName = itemName;
        this.minAttack = minAttack;
        this.maxAttack = maxAttack;
        this.spriteName = spriteName;
        this.itemCategory = itemCategory;
        itemType = "weapon";
    }
}


