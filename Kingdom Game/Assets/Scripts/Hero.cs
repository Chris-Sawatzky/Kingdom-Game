using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero : Combatant
{
    // all heros will be able to switch between classes so just instantiate all of the classess immediately
    public List<HeroClass> classList = new List<HeroClass> {
        new HeroClass("warrior", 1, "str"),
        new HeroClass("mage", 1, "dex"),
        new HeroClass("archer", 1, "int")
    }; // list to put all the classes in so they can be picked at random when the hero is generated

    public int goldCost;
    public string portraitSpriteName;

    //hero equipment
    public Weapon weapon = new Weapon("Fists",1,1,"Fists",1);
    public Armor UBArmor = new Armor("shirt", "upper body", 1,"shirt",2);

    public Hero()
    {
        HP = 100;
        MP = 50;
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
