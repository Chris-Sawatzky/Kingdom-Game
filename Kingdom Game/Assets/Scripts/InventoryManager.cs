using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    public List<Item> inventory;

    /// <summary>
    /// populate the list of items in your inventory
    /// </summary>
    public void AddButtons()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        AddItems(kingdom.weapons);
        AddItems(kingdom.armor);

    }

    /// <summary>
    /// removes all of the buttons from the list
    /// </summary>
    public void RemoveButtons()
    {
        foreach (Transform button in contentPanel)
        {
            Destroy(button.gameObject);
        }
    }

    private void AddItems(List<Item> list)
    {
        inventory = list;

        for (int i = 0; i < inventory.Count; i++)
        {
            Item item = inventory[i];
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            Inventory sellButton = newButton.GetComponent<Inventory>();
            sellButton.Setup(item, this);
            
        }
    }

    /// <summary>
    /// sells the item that was clicked from the proper kingdom inventory list based on the itemCategory and adds gold to the kingdoms resources 
    /// </summary>
    /// <param name="item"></param>
    public void sellItem(Item item)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        if (item.itemCategory == 1)
        {
            kingdom.weapons.Remove(item);
        }
        else if (item.itemCategory == 2)
        {
            kingdom.armor.Remove(item);
        }
        RemoveButtons();
        AddButtons();
        kingdom.gold += item.goldCost;//TODO use the sell price rather than the gold cost
    }
}
