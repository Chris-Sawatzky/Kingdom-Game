using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateHero : MonoBehaviour
{
    public Button button;
    public Text heroName;
    public Text strength;
    public Text dexterity;
    public Text intelligence;
    public Text heroClass;
    public Text goldCost;

    public Image heroImage;

    private Hero hero;
    private HeroList heroList;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    // setup the button to display in the crafting list
    public void Setup(Hero currentHero, HeroList currentList)
    {
        hero = currentHero;

        heroName.text = hero.name;
        strength.text = "Str: " + hero.strength;
        dexterity.text = "Dex: " + hero.dexterity;
        intelligence.text = "Int: " + hero.intelligence;
        heroClass.text = hero.getActiveClass().className;
        heroImage.sprite = Resources.Load<Sprite>(hero.spriteName);
        goldCost.text = "Cost: " + hero.goldCost;

        heroList = currentList;
    }

    public void HandleClick()
    {
        heroList.hireHero(hero);
    }
}
