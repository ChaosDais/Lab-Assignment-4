using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SolutionOne : MonoBehaviour
{
    public string characterName;
    public string className;
    public int level;
    public int conScore;
    public bool isHillDwarf;
    public bool hasTough;
    public bool isHPAveraged;
    private float hp;
    private List<string> partyMembers = new List<string>();

    private Dictionary<string, int> classes = new Dictionary<string, int>()
    {
        { "Artificer", 8 }, {"Barbarian", 12 }, {"Bard", 8 }, {"Cleric", 8 }, {"Druid", 8 }, {"Fighter", 10 },
        { "Monk", 8 }, {"Ranger", 10 }, {"Rogue", 8 }, {"Paladin", 10 }, {"Sorcerer", 6 }, {"Wizard", 6 }, {"Warlock", 8 }
    };

    private int[] modifier = 
    {
        -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10
    };

    void Start()
    {
        calcHP();
    }

    private void calcHP()
    {
        partyMembers.Add(characterName + " the " + className);
	    rollHP();
	
	    if(isHillDwarf)
        {
            hp += level;
        }
        if (hasTough) 
        {
            hp += 2 * level;
        }

        Debug.LogFormat("HP: {0}", hp);
    }

    private void rollHP()
    {
        for (int i = 0; i < level; i++)
        {
            if (isHPAveraged)
                hp += (classes[className] + 1) / 2 + modifier[conScore];
            else
                hp += Random.Range(1, classes[className]) + modifier[conScore];
        }
    }
}
