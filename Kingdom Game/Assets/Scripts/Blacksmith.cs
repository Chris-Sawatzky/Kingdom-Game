using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blacksmith : MonoBehaviour
{
    public int level = 0;
    public int upgradeCost = 10;

    public Text levelAsText;

    // Update is called once per frame
    void Update()
    {
        if (levelAsText == null)
        {
            return;
        }
        else
        {
            levelAsText.text = "Level: " + level;
        }
        
    }

    public void upgradeBuilding()
    {
        Kingdom kingdom = gameObject.GetComponent("Kingdom") as Kingdom;
        if(kingdom.gold >= upgradeCost)
        {
            kingdom.gold = kingdom.gold - upgradeCost;
            level++;
            levelAsText.text = "Level: " + level;
            upgradeCost = upgradeCost + 5; //TODO dertermine a formula for calculating the upgrade cost for buildings
        }

        
    }
}
