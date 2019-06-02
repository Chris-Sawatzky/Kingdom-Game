using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public Button button;
    public Text itemName;
    public Text goldCost;
    public Text itemPower;
    public Image itemImage;

    private Item item;
    private Weapon weapon;
    private Armor armor;
    private ItemList itemList;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

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
        itemImage.sprite = Resources.Load<Sprite>(item.spriteName);
        


        itemList = currentList;
    }

    public void HandleClick()
    {
        itemList.craftItem(item);
    }
}
