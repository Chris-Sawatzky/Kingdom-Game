using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero
{
    public string name;
    // all heros will be able to switch between classes so just instantiate all of the classess immediately
    private HeroClass warrior = new HeroClass("warrior", 1, "str");
    private HeroClass mage = new HeroClass("mage", 1, "dex");
    private HeroClass archer = new HeroClass("archer", 1, "int");

    public List<HeroClass> classList = new List<HeroClass>(); // list to put all the classes in so they can be picked at random when the hero is generated

    //hero stats
    public int HP = 100;
    public int MP = 50;

    public int strength;
    public int dexterity;
    public int intelligence;
    public int goldCost;
    public string spriteName;

    //hero equipment
    public Weapon weapon;
    public Armor chest;

    public Hero()
    {
        classList.Add(warrior);
        classList.Add(mage);
        classList.Add(archer);
    }

    public string getActiveClass()
    {
        string activeClass = "";
        bool classFound = false;
        int classToCheck = 0;

        while (!classFound)
        {
            if (classList[classToCheck].active)
            {
                classFound = true;
                activeClass = classList[classToCheck].className;
            }
            classToCheck++;
        }
        return activeClass;
    }
}
