﻿using System;
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
    public int wood = 0;
    public int stone = 0;

    //variables to be displayed on screen
    public Text KingdomName;
    public Text goldAsText;

    public List<Item> weapons;
    public List<Item> armor;


    public GameObject inputField;
    public void assignKingdomName()
    {
        name = inputField.GetComponent<InputField>().text;
        Debug.Log("Kingdom name is " + name);
    }

    
    void Update()
    {
    }

    public KingdomData CreateKingdomDataObject()
    {
        Blacksmith blacksmith = gameObject.GetComponent("Blacksmith") as Blacksmith;
        

        KingdomData data = new KingdomData();

        data.name = name;
        data.gold = gold;
        data.blacksmithLevel = blacksmith.level;
        data.bsUpgradeCost = blacksmith.upgradeCost;

        //TODO still need to be able to save the inventory lists


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

            KingdomName.text = name;
            goldAsText.text = "Gold: " + gold;

            //load the data for each of the buildings
            Blacksmith blacksmith = gameObject.GetComponent("Blacksmith") as Blacksmith;
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
