using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItem : MonoBehaviour
{
    public Button button;
    public Text itemName;
    public Text goldCost;
    public Image itemImage;

    private Item item;
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
