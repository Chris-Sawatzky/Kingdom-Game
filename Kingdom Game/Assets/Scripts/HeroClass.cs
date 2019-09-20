using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HeroClass
{
    public string className;
    public int classLevel;
    public string baseStat;
    public bool active = false;


    public HeroClass(string className, int classLevel, string baseStat)
    {
        this.className = className;
        this.classLevel = classLevel;
        this.baseStat = baseStat;
    }

    public void activate()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }
}
