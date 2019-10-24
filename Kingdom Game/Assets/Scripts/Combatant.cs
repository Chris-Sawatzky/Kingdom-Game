using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Combatant
{
    public string name;
    // the sprite will be displayed in the battler as a full monster not just a character portrait
    public string spriteName;
    public int HP;
    public int MP;

    public int strength;
    public int dexterity;
    public int intelligence;
}
