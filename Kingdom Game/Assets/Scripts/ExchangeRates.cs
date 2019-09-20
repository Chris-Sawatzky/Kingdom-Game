using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExchangeRates
{
    private string nameOfExchange;
    public int valuePerOneGold;

    public ExchangeRates(string name, int value)
    {
        nameOfExchange = name;
        valuePerOneGold = value;
    }
}
