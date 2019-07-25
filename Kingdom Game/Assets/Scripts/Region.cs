using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{

    public int regionID;
    public string regionName;
    public bool isCompleted;
    public bool isAvailable;
    

    // Start is called before the first frame update
    void Start()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        setAvailability(kingdom);
        checkCompletion(kingdom);
        //when the game starts if isAvailable is true, set the button to be active
        if (!isAvailable)
        {
            this.transform.gameObject.SetActive(false);
        }
    }

    void checkCompletion(Kingdom kingdom)
    {
        if(regionID < kingdom.completedRegions)
        {
            isCompleted = true;
        }
    }

    //set isAvailable based on the number of completed regions saved in the Kingdom
    void setAvailability(Kingdom kingdom)
    {
        if(regionID <= kingdom.completedRegions)
        {
            isAvailable = true;
        }
    }

    
    
}
