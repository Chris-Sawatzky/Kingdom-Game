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

    public Hero heroToEquip;

    public void displayHero(Hero hero)
    {
        heroToEquip = hero;

        displayHeroStats();
        displayHeroWeapon();
    }

    private void displayHeroStats()
    {
        heroName.text = heroToEquip.name;
    }

    public void displayHeroWeapon()
    {
        //these buttons will be invisible and should only be visible after clicking on a hero
        GameObject weaponButton = GameObject.Find("Hero List").transform.GetChild(3).gameObject;
        GameObject removeWeaponButton = GameObject.Find("Hero List").transform.GetChild(5).gameObject;

        weaponButton.SetActive(true);
        removeWeaponButton.SetActive(true);

        weaponName.text = heroToEquip.weapon.itemName;

        weaponPower.text = heroToEquip.weapon.minAttack + " - " + heroToEquip.weapon.maxAttack;

        weaponImage.sprite = Resources.Load<Sprite>(heroToEquip.weapon.spriteName);
    }

    private void displayHeroArmor()
    {

    }

    //TODO Major bug at the moment - any equipment that is unequiped will be lost, this will be handled with the unequip method
    public void equipToHero(Item itemToEquip)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        if (itemToEquip.itemCategory == 1)
        {
            //unequip the old weapon
            unequipWeaponFromHero();
            //equip the weapon to the selected hero
            Weapon weaponToEquip = (Weapon)itemToEquip;
            heroToEquip.weapon = weaponToEquip;
            displayHeroWeapon();

            //remove the weapon from the Kingdoms inventory
            kingdom.weapons.Remove(weaponToEquip);

            //re-display the weapon list without the now equipped weapon
            RemoveButtons();
            displayWeaponList();
        }
    }

    public void unequipWeaponFromHero()
    {
        //check and make sure the the hero has an actual weapon equipped
        if(!heroToEquip.weapon.itemName.Equals("Fists"))
        {
            //move the old weapon the the kingdoms list of weapons
            Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
            kingdom.weapons.Add(heroToEquip.weapon);

            //change the heros weapon to be "unequipped
            heroToEquip.weapon = new Weapon("Fists", 1, 1, "Fists", 1);
        }
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

    public void clearStats()
    {
        heroName.text = "";
    }

    public void RemoveButtons()
    {
        foreach (Transform button in contentPanel)
        {
            Destroy(button.gameObject);
        }
    }
}
