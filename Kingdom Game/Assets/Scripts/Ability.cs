using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    public string abilityName;
    public string abilityDescription;
    public int lvlRequirement; // the level the class has to be in order to use the ability
    public int hitPercentage; // the modifier for determing the chance to hit from 0 to 100
    public int dmgRatio; // modifier for determing the damage dealt
    public int cost;
    public string abilityStat;
    //TODO add effects to the ability ie: stun, burn, freeze etc.

    /// <summary>
    /// determine the base parameters of the ability
    /// </summary>
    /// <param name="name">the name of the ability</param>
    /// <param name="desc">the description of the ability</param>
    /// <param name="lvlReq">the level required of the Combatant to use the ability</param>
    /// <param name="hitPercent">the base chance with no modifiers to use the ability</param>
    /// <param name="dmgRatio">the multiplier to be used with the ability to determine damage</param>
    /// <param name="mpCost">the cost of MP to use the ability</param>    
    public Ability(string name, string desc, int lvlReq, int hitPercent, int dmgRatio, int mpCost, string abilityStat)
    {
        abilityName = name;
        abilityDescription = desc;
        lvlRequirement = lvlReq;
        hitPercentage = hitPercent;
        this.dmgRatio = dmgRatio;
        cost = mpCost;
        this.abilityStat = abilityStat;
    }

    //TODO create a method to change the parameters of an ability based on the heros stats
    public void setAbilityParameters()
    {

    }

    public void useAbility(Combatant target)
    {
        //TODO determina formula for dealing damage with the ability
        if(Random.Range(1,100) < hitPercentage) //if the number generated falls within the hit percentage, ie below it the ability will hit
        {
            
        }
    }

    public void determineDamage()
    {

    }

}
