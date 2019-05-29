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
    private InventoryManager inventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    // setup the button to display in the crafting list
    public void Setup(Item currentItem, InventoryManager currentInventory)
    {
        item = currentItem;
        itemName.text = item.itemName;
        sellPrice.text = item.goldCost.ToString(); //TODO make the sellPrice and gold cost different
        itemImage.sprite = Resources.Load<Sprite>(item.spriteName);


        inventoryManager = currentInventory;
    }

    public void HandleClick()
    {
        inventoryManager.sellItem(item);
    }
}
