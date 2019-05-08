using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemList : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    public List<Item> itemList;


    // Start is called before the first frame update
    void Start()
    {
        AddButtons();
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            CraftItem craftButton = newButton.GetComponent<CraftItem>();
            craftButton.Setup(item, this);
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
                kingdom.weapons.Add(item);
            }
            else if (item.itemCategory == 2)
            {
                kingdom.armor.Add(item);
            }
        }
    }
}
