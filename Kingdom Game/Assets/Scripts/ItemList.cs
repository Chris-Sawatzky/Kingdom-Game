using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    public List<Weapon> weaponList;
    public List<Armor> armorList;

    //TODO this class will ne to be updated with all of its logic when more buildings are added

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// populate the list of items in your inventory uses a different method than the rest of the shops to display the sell price 
    /// of an already possesed item (could still change it to have two different setups in the CraftItem class, one for crafting and one for selling)
    /// </summary>
    public void ShowInventory()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        weaponList = kingdom.weapons;
        armorList = kingdom.armor;

        for (int i = 0; i < weaponList.Count; i++)
        {
            Weapon weapon = weaponList[i];
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            Inventory sellButton = newButton.GetComponent<Inventory>();

            sellButton.Setup(weapon, this);
        }

        for (int i = 0; i < armorList.Count; i++)
        {
            Armor armor = armorList[i];
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            Inventory sellButton = newButton.GetComponent<Inventory>();

            sellButton.Setup(armor, this);
        }
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

    /// <summary>
    /// sells the item that was clicked from the proper kingdom inventory list based on the itemCategory and adds gold to the kingdoms resources 
    /// </summary>
    /// <param name="item"></param>
    public void sellItem(Item item)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        if (item.itemCategory == 1)
        {
            kingdom.weapons.Remove((Weapon)item);
        }
        else if (item.itemCategory == 2)
        {
            kingdom.armor.Remove((Armor)item);
        }
        RemoveButtons();
        ShowInventory();
        kingdom.gold += item.sellPrice;
    }

    /// <summary>
    /// populate the list of items you can craft will display the weapons first and then the armors
    /// (I feel like there is a better way to do this but I cant think of it)
    /// </summary>
    public void AddButtons()
    {
        Blacksmith blacksmith = GameObject.Find("Kingdom").GetComponent<Blacksmith>();
        for (int i = 0; i < weaponList.Count; i++)
        {
            
            Weapon weapon = weaponList[i];
            if (weapon.buildingLvl <= blacksmith.level)
            {
                GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
                newButton.transform.SetParent(contentPanel);

                CraftItem craftButton = newButton.GetComponent<CraftItem>();


                craftButton.Setup(weapon, this);
            }
            
        }

        for (int i = 0; i < armorList.Count; i++)
        {
            Armor armor = armorList[i];
            if (armor.buildingLvl <= blacksmith.level)
            {
                GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
                newButton.transform.SetParent(contentPanel);

                CraftItem craftButton = newButton.GetComponent<CraftItem>();

                craftButton.Setup(armor, this);
            }
        }
    }

    /// <summary>
    /// craft the item and add it to the kingdoms appropriate list given that all conditions are met
    /// ie. materials and building level
    /// </summary>
    /// <param name="item"></param>
    public void craftItem(Item item)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        Blacksmith blacksmith = GameObject.Find("Kingdom").GetComponent<Blacksmith>();
        if (kingdom.gold >= item.goldCost && blacksmith.level >= item.buildingLvl)
        {
            kingdom.gold -= item.goldCost;
            if (item.itemCategory == 1)
            {
                kingdom.weapons.Add((Weapon)item);
            }
            else if (item.itemCategory == 2)
            {
                kingdom.armor.Add((Armor)item);
            }
        }
    }
}
