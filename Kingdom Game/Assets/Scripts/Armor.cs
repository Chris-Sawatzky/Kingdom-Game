using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Armor : Item
{
    public int defenseRating;
    //will determine whether it goes on head, upper, or lower body
    public string bodyLocation;

    public Armor(string name, string bodyLocation, int defenseRating, string spriteName, int itemCategory)//TODO get rid of itemCategory in Armor and just use itemType
    {
        itemName = name;
        this.bodyLocation = bodyLocation;
        this.defenseRating = defenseRating;
        this.spriteName = spriteName;
        this.itemCategory = itemCategory;
        itemType = "armor";

    }
}
