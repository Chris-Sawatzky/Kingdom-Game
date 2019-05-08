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

        
    }


    public void upgradeBuilding()
    {
        Kingdom kingdom = gameObject.GetComponent("Kingdom") as Kingdom;
        if(kingdom.gold >= upgradeCost)
        {
            kingdom.gold -= upgradeCost;
            kingdom.goldAsText.text = "Gold: " + kingdom.gold;
            level++;
            levelAsText.text = "Level: " + level;

            upgradeCost = upgradeCost + 5; //TODO determine a formula for calculating the upgrade cost for buildings
        }
    }
}
