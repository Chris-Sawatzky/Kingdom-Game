using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{
    public string name;
    // all heros will be able to switch between classes so just instantiate all of the classess immediately
    public List<HeroClass> classList = new List<HeroClass> {
        new HeroClass("warrior", 1, "str"),
        new HeroClass("mage", 1, "dex"),
        new HeroClass("archer", 1, "int")
    }; // list to put all the classes in so they can be picked at random when the hero is generated

    //hero stats
    public int HP = 100;
    public int MP = 50;

    public int strength;
    public int dexterity;
    public int intelligence;
    public int goldCost;
    public string spriteName;

    //hero equipment
    public Weapon weapon = new Weapon("Fists",1,1,"Fists",1);
    public Armor chest;

    public Hero()
    {
        
    }

    public HeroClass getActiveClass()
    {
        HeroClass activeClass = null;
        bool classFound = false;
        int classToCheck = 0;

        while (!classFound)
        {
            if (classList[classToCheck].active)
            {
                classFound = true;
                activeClass = classList[classToCheck];
            }
            classToCheck++;
        }
        return activeClass;
    }
}
