using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Button button;
    public Text itemName;
    public Text goldCost;
    public Text itemPower;
    public Text sellPrice;
    public Image itemImage;

    private Item item;
    private Weapon weapon;
    private Armor armor;
    private ItemList itemList;

    // setup the button to display in the crafting list
    public void Setup(Item currentItem, ItemList currentList)
    {
        item = currentItem;

        if (item.itemCategory == 1)
        {
            weapon = (Weapon)item;
            itemPower.text = weapon.minAttack + " - " + weapon.maxAttack;
        }
        else if (item.itemCategory == 2)
        {
            armor = (Armor)item;
            itemPower.text = armor.bodyLocation + " - " + armor.defenseRating;
        }

        itemName.text = item.itemName;
        goldCost.text = item.goldCost.ToString();
        sellPrice.text = item.sellPrice.ToString();
        itemImage.sprite = Resources.Load<Sprite>(item.spriteName);
        


        itemList = currentList;
    }

    /// <summary>
    /// method used buy the item button in the buildings shop menu
    /// </summary>
    public void BuyItem()
    {
        itemList.craftItem(item);
    }

    /// <summary>
    /// method used by the button in the inventory menu
    /// </summary>
    public void SellItem()
    {
        itemList.sellItem(item);
    }

    //TODO add another method to handle equiping items to the hero in order to remove the equipment button class
}
