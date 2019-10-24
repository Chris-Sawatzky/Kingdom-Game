using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster : Combatant
{
    public int level;

    public List<Ability> abilities = new List<Ability>
    {
        new Ability("attack","Basic attack to damage the target",1, 50,1,0,"strength")
    };


}
