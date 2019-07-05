using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{
    //fields for displaying the Heros stats
    public Text heroName;

    //fields for displaying the heros equipment
    public Text weaponName;
    public Text weaponPower;
    public Image weaponImage;

    //the lists of weapon and armor in the kingdoms inventory
    private List<Weapon> weaponList;
    private List<Armor> armorList;

    public Transform contentPanel;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayHero(Hero hero)
    {
        displayHeroStats(hero);
        displayHeroWeapon(hero);
    }

    private void displayHeroStats(Hero hero)
    {
        heroName.text = hero.name;
    }

    private void displayHeroWeapon(Hero hero)
    {
        //the button will be invisible and should only be visible after clicking on a hero
        GameObject button = GameObject.Find("Hero List").transform.GetChild(3).gameObject;
        button.SetActive(true);

        weaponName.text = hero.weapon.itemName;

        weaponPower.text = hero.weapon.minAttack + " - " + hero.weapon.maxAttack;

        weaponImage.sprite = Resources.Load<Sprite>(hero.weapon.spriteName);
    }

    private void displayHeroArmor()
    {

    }

    public void displayWeaponList()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        weaponList = kingdom.weapons;
        armorList = kingdom.armor;

        for (int i = 0; i < weaponList.Count; i++)
        {
            Weapon weapon = weaponList[i];
            generateButton(weapon);
        }
    }

    private void generateButton(Item item)
    {
        GameObject newButton = (GameObject)GameObject.Instantiate(prefab);
        newButton.transform.SetParent(contentPanel);

        EquipmentButton button = newButton.GetComponent<EquipmentButton>();

        button.Setup(item, this);
    }

    public void RemoveButtons()
    {
        foreach (Transform button in contentPanel)
        {
            Destroy(button.gameObject);
        }
    }
}
