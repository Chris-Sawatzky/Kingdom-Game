using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    public string abilityName;
    public int lvlRequirement; // the level the class has to be in order to use the ability
    public int hitPercentage; // the modifier for determing the chance to hit from 0 to 100
    public int dmgRatio; // modifier for determing the damage dealt
    //TODO add effects to the ability ie: stun, burn, freeze etc.

    public Ability(string name, int lvlReq, int hitPercent, int dmgRatio)
    {
        abilityName = name;
        lvlRequirement = lvlReq;
        hitPercentage = hitPercent;
        this.dmgRatio = dmgRatio;
    }

    public void useAbility(Monster monster)
    {
        //TODO determina formula for dealing damage with the ability
    }

}
