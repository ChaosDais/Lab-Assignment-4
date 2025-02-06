using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Solution2 : MonoBehaviour
{
    public String characterName;
    public String className;
    public int level;
    public int conScore;
    public Boolean isHillDwarf;
    public Boolean hasTough;
    public Boolean isHPAveraged;
    private int hp;
    public class Player

    {
        Dictionary<String, int> classes = new Dictionary<String, int>()
    {
        {"Artificer", 8}, {"Barbarian", 12}, {"Bard", 8}, {"Cleric", 8}, {"Druid", 8}, {"Fighter", 10}, {"Monk", 8}, {"Ranger", 10}, {"Rogue", 8}, {"Paladin", 10}, {"Sorcerer", 6}, {"Wizard", 6}, {"Warlock", 8},
        };
        public int[] modifier =
        {
        -5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10
    };
        public String characterName;
        public String className;
        public int level;
        public int conScore;
        public Boolean isHillDwarf;
        public Boolean hasTough;
        public Boolean isHPAveraged;
        private int hp;

        public Player(string characterName, int level, string className, int conScore, Boolean isHillDwarf, Boolean hasTough, Boolean isHPAveraged)
        {
            this.characterName = characterName;
            this.level = level;
            this.className = className;
            this.conScore = conScore;
            this.isHillDwarf = isHillDwarf;
            this.hasTough = hasTough;
            this.isHPAveraged = isHPAveraged;
            this.hp = 0;
        }
        public void calcHP()
        {
            
            if (isHillDwarf)
            {
                hp += level;
            }
            if (hasTough)
            {
                hp += 2 * level;
            }
            Debug.LogFormat("{0}", hp);
        }
        public void rollHP()
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
 

    void Start()
    {
        
        Player player = new Player(characterName, level,className, conScore, isHillDwarf, hasTough, isHPAveraged);
        player.rollHP();
        player.calcHP();
    }
}
