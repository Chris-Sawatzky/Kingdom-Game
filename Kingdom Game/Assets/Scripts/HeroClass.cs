using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/*
 * this class is the classes that will be stored in the hero. it was determined that the player
 * would be able to change the heroes classes and they would level up independantly of one another
 */
public class HeroClass
{
    public string className;
    public int classLevel;
    public string baseStat;
    public bool active = false;

    public List<Ability> abilities = new List<Ability>();

    /// <summary>
    /// create a hero class to be stored in the hero with the parameters provided
    /// </summary>
    /// <param name="className">name if the class</param>
    /// <param name="classLevel">level of the class</param>
    /// <param name="baseStat">the primary stat of the class that attacks will use to determine damage</param>
    public HeroClass(string className, int classLevel, string baseStat)
    {
        this.className = className;
        this.classLevel = classLevel;
        this.baseStat = baseStat;

        assignAbilities();
    }

    /// <summary>
    /// load the abilities for the class into the list of abilites based on the class
    /// </summary>
    public void assignAbilities()
    {
        //all classes will have the ability attack
        Ability attack = new Ability("attack","Basic attack to deal damage to the target", 1, 50, 1,0, "strength");
        abilities.Add(attack);

        //TODO add the abilites for each of the classes in the game

        //if the class is warrior
            //instantiate these abilities
        //else if the class is mage
            //instantiate these abilities
        //else if the class is archer
            //instantiate these abilities
    }

    /// <summary>
    /// set the class to be the currently active class
    /// </summary>
    public void activate()
    {
        active = true;
    }

    /// <summary>
    /// set this class to be inactive as another class has been set to be active
    /// </summary>
    public void deactivate()
    {
        active = false;
    }
}
