using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public int goldCost;
    //public Sprite itemImage;
    public int buildingLvl; // the required level the building must be in order to craft the item

    // the category to determine what type of item it is
    public int itemCategory;
    // 1 = weapon
    // 2 = armor
}
