using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<Region> regions;
    private List<Monster> battleMonsters;
    public Zone zone;
    

    //get the zone that was clicked on
    public void setZone(Zone zone)
    {
        this.zone = zone;
    }

    //use the zones level range to determine which monsters to use in the regions list and send that list into the pre-battle game object
    
    
    /// <summary>
    /// takes in a region and will use the list to find the next region and set it to be active in the game
    /// </summary>
    /// <param name="region">the region that was completed</param>
    public void activateNextRegion(Region region)
    {
        regions[region.regionID + 1].transform.gameObject.SetActive(true);
    }

    static int sortByRegionID(Region r1, Region r2)
    {
        return r1.regionID.CompareTo(r2.regionID);
    }

    public void sortRegions()
    {
        regions.Sort(sortByRegionID);
    }
}
