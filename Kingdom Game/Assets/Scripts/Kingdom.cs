using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Kingdom : MonoBehaviour
{
    //variables to be used in calculations etc.
    //TODO will need to put the resources into a list
    new public string name;
    public int gold = 0;
    public int wood = 0;
    public int stone = 0;

    //variables to be displayed on screen
    public Text KingdomName;
    public Text goldAsText;
    public Text woodAsText;
    public Text stoneAsText;

    public List<Weapon> weapons;
    public List<Armor> armor;

    public List<Hero> heroes;

    // a number that counts the number of completed regions to be used by each regionID to determine if it should be active or not
    public int highestLevelRegionActive = 0;

    public GameObject inputField;
    public void assignKingdomName()
    {
        name = inputField.GetComponent<InputField>().text;
        Debug.Log("Kingdom name is " + name);
    }

    void Update()
    {
        KingdomName.text = name;
        goldAsText.text = "Gold: " + gold;
        woodAsText.text = "Wood: " + wood;
        stoneAsText.text = "Stone: " + stone;
    }

    public KingdomData CreateKingdomDataObject()
    {
        Building blacksmith = GameObject.Find("Blacksmith").GetComponent<Building>();
        //TODO Tailor is not yet saved (am unsure if this building will remain)


        KingdomData data = new KingdomData();

        data.name = name;
        data.gold = gold;
        data.blacksmithLevel = blacksmith.level;
        data.bsUpgradeCost = blacksmith.upgradeCost;


        data.weapons = weapons;
        data.armor = armor;
        data.heroes = heroes;

        data.highestLevelRegionActive = highestLevelRegionActive;

        return data;
    }

    //test method to make sure the gold is being saved and displayed properly
    public void boostGold()
    {
        gold += 100;
    }

    //TODO look into creating multiple save files
    public void SaveKingdom()
    {
        KingdomData data = CreateKingdomDataObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/kingdom.save");
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadKingdom()
    {
        if (File.Exists(Application.persistentDataPath + "/kingdom.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/kingdom.save", FileMode.Open);
            KingdomData data = (KingdomData)bf.Deserialize(file);
            file.Close();

            name = data.name;
            gold = data.gold;


            //load the inventory lists
            weapons = data.weapons;
            armor = data.armor;

            //load the heroes
            heroes = data.heroes;

            highestLevelRegionActive = data.highestLevelRegionActive;

            //load the data for each of the buildings
            Building blacksmith = GameObject.Find("Blacksmith").GetComponent<Building>();
            blacksmith.level = data.blacksmithLevel;
            blacksmith.upgradeCost = data.bsUpgradeCost;
            blacksmith.levelAsText.text = "Level: " + blacksmith.level;
        }
        else
        {
            Debug.Log("No save found");
        }
    }
}
