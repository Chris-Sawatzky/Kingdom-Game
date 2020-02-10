using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO refactor the equipmentManager and ItemList classes together and after that is done I can combine the EquipmentButton and ItemButton classes
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

    //buttons on the screen that should only be visible if the player has selected a hero
    GameObject weaponButton;
    GameObject UBArmorButton;
    GameObject unequipItemButton1;
    GameObject unequipItemButton2;
    GameObject classChangeButton;

    public void deactivateElements()
    {
        //get references to all of the objects that are to be set to false
        weaponButton = GameObject.Find("Hero List").transform.GetChild(3).gameObject;
        UBArmorButton = GameObject.Find("Hero List").transform.GetChild(4).gameObject;
        unequipItemButton1 = GameObject.Find("Hero List").transform.GetChild(6).gameObject;
        unequipItemButton2 = GameObject.Find("Hero List").transform.GetChild(7).gameObject;
        classChangeButton = GameObject.Find("Hero List").transform.GetChild(10).gameObject;

        //set all of the objects to be inactive
        weaponButton.SetActive(false);
        UBArmorButton.SetActive(false);
        unequipItemButton1.SetActive(false);
        unequipItemButton2.SetActive(false);
        classChangeButton.SetActive(false);
    }

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
        //set weapon attributes
        weaponButton.SetActive(true);
        weaponName.text = heroToEquip.weapon.itemName;
        weaponPower.text = heroToEquip.weapon.minAttack + " - " + heroToEquip.weapon.maxAttack;
        weaponImage.sprite = Resources.Load<Sprite>(heroToEquip.weapon.spriteName);

        //set upper body armor attributes
        UBArmorButton.SetActive(true);
        UBArmorName.text = heroToEquip.UBArmor.itemName;
        UBArmorPower.text = heroToEquip.UBArmor.defenseRating.ToString();
        UBArmorImage.sprite = Resources.Load<Sprite>(heroToEquip.UBArmor.spriteName);
    }

    /// <summary>
    /// display the buttons to unequip the corresponding item
    /// </summary>
    public void displayRemoveItemButton()
    {
        unequipItemButton1.SetActive(true);
        unequipItemButton2.SetActive(true);

        classChangeButton.SetActive(true);
    }

    /// <summary>
    /// equips the item that was selected from the list to the appropriate slot on the hero and then
    /// removes it from the kingdoms inventory
    /// </summary>
    /// <param name="itemToEquip">the item to equip on the hero</param>
    public void equipToHero(Item itemToEquip)
    {
        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        if (itemToEquip.itemType.ToLower().Equals("weapon"))
        {
            //unequip the old weapon
            unequipItemFromHero("weapon");
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
        else if (itemToEquip.itemType.Equals("armor"))
        {
            Armor armorToEquip = (Armor)itemToEquip;
            //determine which slot the armor belongs
            if(armorToEquip.bodyLocation.ToLower().Equals("upper body"))
            {
                unequipItemFromHero("upper body");
                heroToEquip.UBArmor = armorToEquip;
            }
            else if (armorToEquip.bodyLocation.ToLower().Equals("lower body"))
            {

            }
            else if (armorToEquip.bodyLocation.ToLower().Equals("head"))
            {

            }

            displayHeroEquipment();

            kingdom.armor.Remove(armorToEquip);

            RemoveButtons();
            displayArmorList(armorToEquip.bodyLocation);
        }
    }

    /// <summary>
    /// removes the weapon from the hero and then adds it back into the kingdoms inventory provided it is equipment
    /// </summary>
    public void unequipItemFromHero(string item)
    {

        Kingdom kingdom = GameObject.Find("Kingdom").GetComponent<Kingdom>();

        //check the item to see what to remove
        if (item.Equals("weapon"))
        {
            //check and make sure the the hero has an actual item equipped
            if (!heroToEquip.weapon.itemName.ToLower().Equals("fists"))
            {
                //move the old weapon the correct list
                kingdom.weapons.Add(heroToEquip.weapon);
                //change the heros weapon to be "unequipped"
                heroToEquip.weapon = new Weapon("Fists", 1, 1, "Fists", 1);
            }
            //else display a message that no weapon is currently equipped
        }
        else if (item.Equals("upper body"))
        {
            if (!heroToEquip.UBArmor.itemName.ToLower().Equals("shirt"))
            {
                kingdom.armor.Add(heroToEquip.UBArmor);

                heroToEquip.UBArmor = new Armor("Shirt", "upper body", 1, "Shirt", 2);
            }
        }

    }

    /// <summary>
    /// displays all of the weapons in the kingdoms inventory
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
    /// <param name="slot">the slot that will be displayed ie. chest/head/legs</param>
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
