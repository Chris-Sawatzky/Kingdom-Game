﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
    public string itemName;
    public int goldCost;
    public int sellPrice;
    public int buildingLvl; // the required level the building must be in order to craft the item
    public string spriteName;

    // the category to determine what type of item it is
    //TODO change the item category to be a string rather than a number for better readability
    public int itemCategory;
    // 1 = weapon
    // 2 = armor
    public string itemType;
}
