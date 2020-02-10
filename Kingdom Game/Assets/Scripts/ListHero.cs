using UnityEngine;
using UnityEngine.UI;

//TODO change name to HeroButton and refactor the HeroSelectList into this class
public class ListHero : MonoBehaviour
{
    public Button button;
    public Text HP;
    public Text MP;
    public Text heroName;
    public Text strength;
    public Text dexterity;
    public Text intelligence;
    public Text heroClass;
    public Text classLevel;

    public Image heroImage;

    private Hero hero;
    private HeroList heroList;
    private EquipmentManager em;

    // setup the button to display in the hero list
    public void Setup(Hero currentHero, HeroList currentList)
    {
        hero = currentHero;

        heroName.text = hero.name;
        HP.text = "HP: " + hero.HP;
        MP.text = "MP: " + hero.MP;
        strength.text = "Str: " + hero.strength;
        dexterity.text = "Dex: " + hero.dexterity;
        intelligence.text = "Int: " + hero.intelligence;
        heroClass.text = hero.GetActiveClass().className;
        classLevel.text = hero.GetActiveClass().classLevel.ToString();
        heroImage.sprite = Resources.Load<Sprite>(hero.portraitSpriteName);

        heroList = currentList;
    }

    public void displayHeroEquipment()
    {
        em = GameObject.Find("Hero Manager").GetComponent<EquipmentManager>();
        em.RemoveButtons();
        em.displayHero(hero);
    }

    public void addHeroSelection()
    {
        heroList.addSelectedHero(hero);
    }
}
