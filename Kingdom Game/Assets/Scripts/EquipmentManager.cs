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

    //fields for displaying the upper body armor
    public Text UBArmorName;
    public Text UBArmorPower;
    public Image UBArmorImage;

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
        displayHeroEquipment();
        displayRemoveItemButton();
        
    }

    private void displayHeroStats()
    {
        heroName.text = heroToEquip.name;
    }

    /// <summary>
    /// displays the selected heroes current equipment
    /// </summary>
    public void displayHeroEquipment()
    {
        //these buttons will be invisible and should only be visible after clicking on a hero
        GameObject weaponButton = GameObject.Find("Hero List").transform.GetChild(3).gameObject;
        GameObject UBArmorButton = GameObject.Find("Hero List").transform.GetChild(4).gameObject;

        //set weapon attributes
        weaponButton.SetActive(true);
        weaponName.text = heroToEquip.weapon.itemName;
        weaponPower.text = heroToEquip.weapon.minAttack + " - " + heroToEquip.weapon.maxAttack;
        weaponImage.sprite = Resources.Load<Sprite>(heroToEquip.weapon.spriteName);

        //set upper body armor attributes
        UBArmorButton.SetActive(true);
        UBArmorName.text = heroToEquip.chest.itemName;
        UBArmorPower.text = heroToEquip.chest.defenseRating.ToString();
        UBArmorImage.sprite = Resources.Load<Sprite>(heroToEquip.chest.spriteName);
    }

    /// <summary>
    /// display the button to unequip the selected item
    /// </summary>
    public void displayRemoveItemButton()
    {
        GameObject unequipItemButton = GameObject.Find("Hero List").transform.GetChild(6).gameObject;
        unequipItemButton.SetActive(true);
    }

    /// <summary>
    /// equips the item that was selected from the list to the appropriate slot on the hero and then
    /// removes it from the kingdoms inventory
    /// </summary>
    /// <param name="itemToEquip">the item to equip on the hero</param>
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
            displayHeroEquipment();

            //remove the weapon from the Kingdoms inventory
            kingdom.weapons.Remove(weaponToEquip);

            //re-display the weapon list without the now equipped weapon
            RemoveButtons();
            displayWeaponList();
        }
        //TODO expand function to equip armor
    }

    /// <summary>
    /// removes the weapon from the hero and then adds it back into the kingdoms inventory provided it is equipment
    /// </summary>
    public void unequipWeaponFromHero()
    {
        //check and make sure the the hero has an actual item equipped
        if(!heroToEquip.weapon.itemName.Equals("Fists"))
        {
            //move the old weapon the correct list
            Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
            kingdom.weapons.Add(heroToEquip.weapon);
            //change the heros weapon to be "unequipped"
            heroToEquip.weapon = new Weapon("Fists", 1, 1, "Fists", 1);
        }
    }

    /// <summary>
    /// displays all of the weapons in the knigdoms inventory
    /// </summary>
    public void displayWeaponList()
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        weaponList = kingdom.weapons;

        for (int i = 0; i < weaponList.Count; i++)
        {
            Weapon weapon = weaponList[i];
            generateButton(weapon);
        }
    }

    /// <summary>
    /// will display all of the armor of the appropriate slot in the kingdoms inventory
    /// </summary>
    /// <param name="slot">the slot that will be displayed ie. chest</param>
    public void displayArmorList(string slot)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();
        armorList = kingdom.armor;

        for (int i = 0; i < armorList.Count; i++)
        {
            Armor armor = armorList[i];
            if(armor.bodyLocation.ToUpper().Equals(slot.ToUpper()))
            {
                generateButton(armor);
            }
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
