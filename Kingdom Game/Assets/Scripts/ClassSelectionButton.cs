using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassSelectionButton : MonoBehaviour
{
    public Button button;

    public Text className;
    public Text primaryStat;
    public Text classLevel;
    public Image classIcon;

    private HeroClass heroClass;
    private ClassManager cm;

    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(HeroClass currentHeroClass, ClassManager cm)
    {
        heroClass = currentHeroClass;
        this.cm = cm;

        className.text = heroClass.className;
        primaryStat.text = heroClass.baseStat;
        classLevel.text = heroClass.classLevel.ToString();
        classIcon.sprite = Resources.Load<Sprite>(heroClass.ClassIconSpriteName);

    }

    private void HandleClick()
    {
        cm.changeClass(heroClass);
    }
}
