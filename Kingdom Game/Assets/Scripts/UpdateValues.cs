using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// used to update the text areas for the other canvases
/// </summary>
public class UpdateValues : MonoBehaviour
{

    //variables to be used in calculations etc.
    private string name;
    private int gold = 0;
    private int wood = 0;
    private int stone = 0;

    //variables to be displayed on screen
    public Text KingdomName;
    public Text goldAsText;

    // Update is called once per frame
    void Update()
    {
        if (KingdomName == null)
        {
            return;
        }
        else
        {
            KingdomName.text = name;
            goldAsText.text = "Gold: " + gold;
        }
    }
}
