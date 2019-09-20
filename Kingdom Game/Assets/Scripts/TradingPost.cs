using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// designed to be able to exchange surplus of gold for other materials such as wood and stone that you may need
/// note: is not to replace the need to aquire from questing just supplement if you need something specific
/// upgrading the building will give better exchange rates
/// </summary>
public class TradingPost : Building
{
    public Kingdom kingdom;
    public InputField inputField;

    private int amountOfGold;

    //TODO determine proper exchange rates
    //exchange rates
    private List<ExchangeRates> exchangeRates = new List<ExchangeRates> {
        new ExchangeRates ("GoldToWood", 10),
        new ExchangeRates ("GoldToStone", 5),
    };
    //TODO use a formula to determine the rate based on the buildings level

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="exchangeRateToUse">value that will index into the exchangeRates list to detemine which rate to use</param>
    public void buyMaterial(int resource)
    {
        int resourceToAdd = 0;
           
        if (kingdom.gold >= amountOfGold && amountOfGold > 0)
        {
            kingdom.gold -= amountOfGold;
            resourceToAdd += amountOfGold * exchangeRates[resource].valuePerOneGold;
        }

        //determine where to add the resources (this statement may get long depending on the different types of resources)
        //TODO Add case statement for each resource type
        switch (resource)
        {
            case 0:
                kingdom.wood += resourceToAdd;
                break;
            case 1:
                kingdom.stone += resourceToAdd;
                break;
        }
    }

    public void setGoldToUse()
    {
        if(inputField.text != "")
        {
            amountOfGold = int.Parse(inputField.text);
        }
            
               
        
    }

    //TODO method to loop through the list of exchange rates changing them when the building is upgraded (will need to determine formula first)
    //will also need to be updated when the game is loaded


}
