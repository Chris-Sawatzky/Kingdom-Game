using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassManager : MonoBehaviour
{
    public EquipmentManager em;

    Hero hero;

    public Text heroName;
    public Text heroClassName;
    public Text heroClassLevel;
    public Text heroSTR;
    public Text heroINT;
    public Text heroDEX;

    public void retrieveHero()
    {
        hero = em.heroToEquip;
        heroName.text = hero.name;
        heroClassName.text = hero.getActiveClass().ToString();
        heroSTR.text = hero.strength.ToString();
        heroINT.text = hero.intelligence.ToString();
        heroDEX.text = hero.dexterity.ToString();
        heroClassLevel.text = hero.getActiveClass().classLevel.ToString();


    }
}
