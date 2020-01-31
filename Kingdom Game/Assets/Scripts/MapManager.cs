using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public List<Region> regions;
    public List<Monster> battleMonsters = new List<Monster>();
    public int numberofMonsters = 3; // the number of monsters to select from the list, or how many battles are going to happen
    public Zone zone;
    

    //get the zone that was clicked on
    public void setZone(Zone zone)
    {
        this.zone = zone;
    }

    /// <summary>
    /// use the zones level range to determine which monsters to use in the regions list and send that list into the battleData class
    /// </summary>
    public void buildMonsterList()
    {
        //create a temporary list of the monsters in that region that can be manipulated without changing the list in the region
        List<Monster> tempList = new List<Monster>(regions[zone.parentRegionID].regionMonsters);

        //clear the current list of monsters, so you only have the three that you want
        battleMonsters.Clear();

        // loop through for however many monster you wnat to battle
        for (int i = 0; i < numberofMonsters; i++)
        {
            Monster monster = null;

            do
            {
                int tempListIndex = Random.Range(0, tempList.Count - 1);//determine what index to check
                Monster monsterToCheck = tempList[tempListIndex]; // get the monster from that index

                // if the monster at the index checked does not fall within the correct level range remove it from the temp list
                // otherwise assign it to monster to be added to the list of monsters to battle
                if (monsterToCheck.level > zone.maxLevel && monsterToCheck.level < zone.minLevel && monsterToCheck.bossMonster == true)
                {
                    tempList.RemoveAt(tempListIndex);
                }
                else
                {
                    monster = monsterToCheck;
                }
                
            }
            while (monster == null);

            battleMonsters.Add(monster);

            //TODO if bossZone is true then add the region boss from the monster list
        }
        assignToBattlePrepData();
    }
    
    /// <summary>
    /// assigns the information for the upcoming battle (the list of monsters that was built, and the zone the battle will take place in)
    /// from this class into the static class battlePrepData
    /// </summary>
    private void assignToBattlePrepData()
        /*TODO instead of assigning this to the BattlePrepData class (that class is no longer needed for the route we have decided to take)
         *this data will be directly placed into the battle manager which will then load the game objects with the given data 
         */
    {
        BattlePrepData.monsters = battleMonsters;
        BattlePrepData.zone = zone;
    }

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
