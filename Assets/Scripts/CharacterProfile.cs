using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterProfile
{
    public int charID;
    public string charName;
    public int charClassIndex;
    public int charStatPoints;
    public int charLevel;
    public int charExperience;

    // Character Stats
    public int charCON;
    public int charSTR;
    public int charDEX;
    public int charINT;
    public int charWIS;

    public CharacterProfile()
    {
        charName = "New Character";
        charClassIndex = 0;
        charStatPoints = 50;
        charLevel = 1;
        charExperience = 0;

        // Get Character Stats from StatManager
        charCON = 0;
        charSTR = 0;
        charDEX = 0;
        charINT = 0;
        charWIS = 0;
    }
}
