using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedHero : MonoBehaviour
{
    public Text heroName;
    public Text heroClass;
    public Text heroClassLevel;
    public Image portrait;

    public void displaySelectedHero(Hero hero)
    {
        heroName.text = hero.name;
        heroClass.text = hero.getActiveClass().className;
        heroClassLevel.text = "Level: " + hero.getActiveClass().classLevel;
        portrait.sprite = Resources.Load<Sprite>(hero.portraitSpriteName);
    }

    public void clearHero()
    {
        heroName.text = "";
        heroClass.text = "";
        heroClassLevel.text = "";
        portrait.sprite = null;
    }
}
