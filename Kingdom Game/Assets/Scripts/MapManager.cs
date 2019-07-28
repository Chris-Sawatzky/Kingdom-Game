using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<Region> regions;
    

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
