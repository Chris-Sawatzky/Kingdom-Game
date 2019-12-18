using UnityEngine;
using UnityEngine.UI;

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

    public Image heroImage;

    private Hero hero;
    private HeroList heroList;
    private EquipmentManager em;


    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

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
        heroClass.text = hero.getActiveClass().className;
        heroImage.sprite = Resources.Load<Sprite>(hero.portraitSpriteName);

        heroList = currentList;
    }

    public void HandleClick()
    {
        em = GameObject.Find("Hero Manager").GetComponent<EquipmentManager>();
        em.RemoveButtons();
        em.displayHero(hero);
    }
}
