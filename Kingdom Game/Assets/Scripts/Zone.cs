using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Zone : MonoBehaviour
{
    //each zone will need to know which region it belongs to
    public int parentRegionID;
    public int maxLevel;
    public int minLevel;

    public void sendToManager()
    {
        MapManager mM = GameObject.Find("MapManager").GetComponent<MapManager>();

        mM.setZone(this);
    }
}
