using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroList : MonoBehaviour
{
    public GameObject prefab;
    public Transform contentPanel;
    public int numHeroes;
    public List<string> heroNames;

    //the list that will store the heroes to go on the mission
    public List<Hero> missionRoster;

    //the list of selectedHero prefabs used to display the hero on the screen
    public List<SelectedHero> heroDisplay;

    //TODO add a cost associated with generating heroes
    public void GenerateHeroes()
    {
        // only generate the number of heroes specified in the editor
        for (int i = 0; i < numHeroes; i++)
        {
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            GenerateHero heroButton = newButton.GetComponent<GenerateHero>();

            Hero newHero = new Hero();
            // choose a name from the list in the editor at random
            newHero.name = heroNames[Random.Range(0, heroNames.Count - 1)];

            //set the sprite name to be the heros name with Portrait on the end ie "grothnakPortrait"
            //ALL SPRITES MUST FOLLOW THIS CONVENTION
            newHero.portraitSpriteName = newHero.name + "Portrait";

            chooseClass(newHero);
            generateStats(newHero);
            determineCost(newHero);

            heroButton.Setup(newHero, this);


        }
    }
    //TODO pass the button style to use as a variable and refactor these into one method, or possibly refactor the buttons into one class
    /// <summary>
    /// list the heros in the equipment screen to be able to change equipment
    /// </summary>
    public void ListHeros()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        for (int i = 0; i < kingdom.heroes.Count; i++)
        {
            GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
            newButton.transform.SetParent(contentPanel);

            ListHero heroButton = newButton.GetComponent<ListHero>();

            heroButton.Setup(kingdom.heroes[i], this);
        }
    }

    /// <summary>
    /// add the hero that was selected from the hero selection screen to the list selectedHeros
    /// </summary>
    public void addSelectedHero(Hero hero)
    {
        //check if there are less than 4 heros in the list
        if (missionRoster.Count < 4 && !missionRoster.Contains(hero))
        {
            missionRoster.Add(hero);
            heroDisplay[missionRoster.Count - 1].displaySelectedHero(hero);
        }
        //update the screen to show the hero that was selected in the correct display area
        
    }

    public void clearAll()
    {
        missionRoster.Clear();
        for (int i = 0; i < heroDisplay.Count; i++)
        {
            heroDisplay[i].clearHero();
        }
    }

    public void chooseClass(Hero hero)
    {
        // picks a random class in the heroes class list to activate (set their default class)
        hero.classList[Random.Range(0, hero.classList.Count - 1)].activate();
    }

    public void generateStats(Hero hero)
    {
        hero.strength = Random.Range(5, 10);
        hero.dexterity = Random.Range(5, 10);
        hero.intelligence = Random.Range(5, 10);

        //TODO generate specific stats based on the class
    }

    public void determineCost(Hero hero)
    {
        // TODO Determine better formula for calculating cost
        hero.goldCost = hero.strength + hero.dexterity + hero.intelligence;

    }

    public void removeButtons()
    {
        foreach (Transform button in contentPanel)
        {
            Destroy(button.gameObject);
        }
    }

    public void hireHero(Hero hero)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        if(kingdom.gold >= hero.goldCost)
        {
            kingdom.gold -= hero.goldCost;
            kingdom.heroes.Add(hero);
            //TODO remove the button for the hero that was hired
        }
    }
}
