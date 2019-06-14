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
    public List<string> sprites;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //TODO add acost associated with generating heroes
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

            //choose a sprite name to assign to the hero at random from the list in editor
            //this will be loaded later
            newHero.spriteName = sprites[Random.Range(0, sprites.Count - 1)];

            chooseClass(newHero);
            generateStats(newHero);
            determineCost(newHero);

            heroButton.Setup(newHero, this);


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
        }
    }
}
