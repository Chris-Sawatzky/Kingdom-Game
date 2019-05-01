using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kingdom : MonoBehaviour
{
    public string name;


    public GameObject inputField;
    public void assignKingdomName()
    {
        name = inputField.GetComponent<InputField>().text;
        Debug.Log("Kingdom name is " + name);
    }

    public Text KingdomName;
    void Update()
    {
        if(KingdomName == null)
        {
            return;
        }
        else
        {
            KingdomName.text = name;
        }
        
    }
}
