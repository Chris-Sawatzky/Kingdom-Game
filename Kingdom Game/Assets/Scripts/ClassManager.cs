using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassManager : MonoBehaviour
{
    public EquipmentManager em;

    private Hero hero;

    public Text heroName;
    public Text heroClassName;
    public Text heroClassLevel;
    public Text heroSTR;
    public Text heroINT;
    public Text heroDEX;

    public Transform contentPanel;
    public GameObject prefab;

    /// <summary>
    /// Gets the hero from the equipment manager and displays their stats on the screen
    /// </summary>
    public void retrieveHero()
    {
        hero = em.heroToEquip;
        displayHeroInfo();
    }

    private void displayHeroInfo()
    {
        heroName.text = hero.name;
        heroClassName.text = hero.getActiveClass().ToString();
        heroSTR.text = hero.strength.ToString();
        heroINT.text = hero.intelligence.ToString();
        heroDEX.text = hero.dexterity.ToString();
        heroClassLevel.text = hero.getActiveClass().classLevel.ToString();
    }

    /// <summary>
    /// displays all of the classes the hero can use
    /// </summary>
    public void displayHeroClasses()
    {
        for (int i = 0; i < hero.classList.Count; i++)
        {
            HeroClass heroClass = hero.classList[i];
            //only display the classes that are not active IE classes you can change to
            if (!heroClass.active)
            {
                generateButton(heroClass);
            }
        }
    }

    private void generateButton(HeroClass heroClass)
    {
        GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
        newButton.transform.SetParent(contentPanel);

        ClassSelectionButton button = newButton.GetComponent<ClassSelectionButton>();
        button.Setup(heroClass, this);
    }

    public void changeClass(HeroClass heroClass)
    {
        //change the currently active class to be inactive
        hero.getActiveClass().deactivate();

        for (int i = 0; i < hero.classList.Count; i++)
        {
            if(hero.classList[i].className.Equals(heroClass.className))
            {
                hero.classList[i].activate();
            }
        }
        removeButtons();
        displayHeroInfo();
        displayHeroClasses();
    }

    public void removeButtons()
    {
        foreach (Transform button in contentPanel)
        {
            Destroy(button.gameObject);
        }
    }
}
