using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    public Button button;
    public Text equipmentName;
    public Text equipmentPower;
    public Image equipmentImage;

    private Item item;
    private Weapon weapon;
    private Armor armor;

    private EquipmentManager em;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(Item currentItem, EquipmentManager em)
    {
        item = currentItem;
        this.em = em;

        equipmentName.text = item.itemName;

        equipmentImage.sprite = Resources.Load<Sprite>(item.spriteName);

        if (item.itemCategory == 1)
        {
            weapon = (Weapon)item;
            equipmentPower.text = weapon.minAttack + " - " + weapon.maxAttack;
        }
        else if (item.itemCategory == 2)
        {
            armor = (Armor)item;
            equipmentPower.text = armor.bodyLocation + " - " + armor.defenseRating;
        }
    }

    private void HandleClick()
    {
        //em = GameObject.Find("Hero Manager").GetComponent<EquipmentManager>();
        em.equipToHero(item);
    }
}
