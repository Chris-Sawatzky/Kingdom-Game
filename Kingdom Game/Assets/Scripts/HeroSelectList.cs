using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectList : MonoBehaviour
{
    public Button button;

    public Text heroName;
    public Text heroClass;
    public Text classLevel;
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
        heroClass.text = hero.getActiveClass().className;
        classLevel.text = "Level: " + hero.getActiveClass().classLevel;
        heroImage.sprite = Resources.Load<Sprite>(hero.spriteName);

        heroList = currentList;
    }

    public void HandleClick()
    {
        
    }
}
