using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Region : MonoBehaviour
{

    public int regionID;
    public string regionName;
    public bool isCompleted; //TODO not actually using this anywhere, cosider removing
    public bool isAvailable;
    Kingdom kingdom;
    private MapManager mM;

    public List<Monster> regionMonsters;
    

    // Start is called before the first frame update
    void Start()
    {
        kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        mM = GameObject.Find("MapManager").GetComponent<MapManager>();

        setAvailability(kingdom);
        checkCompletion(kingdom);
        //when the game starts if isAvailable is true, set the button to be active
        if (!isAvailable)
        {
            transform.gameObject.SetActive(false);
        }

        //each reggion will add itself to the list in the manager
        mM.regions.Add(this);

        //after it is added it will call the managers method to sort itself to make sure they are in the correct order
        mM.sortRegions();
    }

    /// <summary>
    /// when a region is completed set the variable in the kingdom and then call the method in the mapManager to activate the next region
    /// </summary>
    public void completeRegion()
    {
        if(regionID >= kingdom.highestLevelRegionActive)
        {
            kingdom.highestLevelRegionActive = regionID + 1;
        }
        mM.activateNextRegion(this);
    }

    void checkCompletion(Kingdom kingdom)
    {
        if(regionID < kingdom.highestLevelRegionActive)
        {
            isCompleted = true;
        }
    }

    /// <summary>
    /// set isAvailable based on the number of completed regions saved in the Kingdom
    /// </summary>
    void setAvailability(Kingdom kingdom)
    {
        if(regionID <= kingdom.highestLevelRegionActive)
        {
            isAvailable = true;
        }
    }

    
    
}
