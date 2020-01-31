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

    public void Setup(Hero currentHero, HeroList currentList)
    {
        hero = currentHero;

        heroName.text = hero.name;
        heroClass.text = hero.GetActiveClass().className;
        classLevel.text = "Level: " + hero.GetActiveClass().classLevel;
        heroImage.sprite = Resources.Load<Sprite>(hero.portraitSpriteName);

        heroList = currentList;
    }

    public void HandleClick()
    {
        heroList.addSelectedHero(hero);
    }
}
