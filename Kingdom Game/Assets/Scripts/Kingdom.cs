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
    new public string name;
    public int gold = 0;
    public int wood = 0;// not saved yet
    public int stone = 0;// not saved yet

    //variables to be displayed on screen
    public Text KingdomName;
    public Text goldAsText;

    public List<Weapon> weapons;
    public List<Armor> armor;

    public List<Hero> heroes;


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
    }

    public KingdomData CreateKingdomDataObject()
    {
        Blacksmith blacksmith = GameObject.Find("Blacksmith").GetComponent<Blacksmith>();
        //TODO Tailor is not yet saved (am unsure if this building will remain)


        KingdomData data = new KingdomData();

        data.name = name;
        data.gold = gold;
        data.blacksmithLevel = blacksmith.level;
        data.bsUpgradeCost = blacksmith.upgradeCost;


        data.weapons = weapons;
        data.armor = armor;
        data.heroes = heroes;


        return data;
    }

    //test method to make sure the gold is being saved and displayed properly
    public void boostGold()
    {
        gold++;
    }

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

            //load the data for each of the buildings
            Blacksmith blacksmith = GameObject.Find("Blacksmith").GetComponent<Blacksmith>();
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
