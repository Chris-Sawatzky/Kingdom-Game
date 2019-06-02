using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Button button;
    public Text itemName;
    public Text sellPrice;
    public Image itemImage;

    private Item item;
    private ItemList inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    // setup the button to display in the crafting list
    public void Setup(Item currentItem, ItemList inventory)
    {
        item = currentItem;
        itemName.text = item.itemName;
        sellPrice.text = item.sellPrice.ToString();
        itemImage.sprite = Resources.Load<Sprite>(item.spriteName);


        inventoryManager = inventory;
    }

    public void HandleClick()
    {
        inventoryManager.sellItem(item);
    }
}
