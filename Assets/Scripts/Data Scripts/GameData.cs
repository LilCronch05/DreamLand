// These are the classes that store the data for the player character, areas, etc.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int charID;
    public string charName;
    public int charClass;
    public int charLevel;
    public int charCON;
    public int charSTR;
    public int charDEX;
    public int charINT;
    public int charWIS;

    public GameData()
    {
        charID = 0;
        charName = "Empty";
        charClass = 0;
        charLevel = 0;
        charCON = 0;
        charSTR = 0;
        charDEX = 0;
        charINT = 0;
        charWIS = 0;
    }
}

public class AreaData
{
    public int areaID;
    public bool[] hostileCreatures;

    public AreaData(int id, int count)
    {
        areaID = id;
        hostileCreatures = new bool[count];
    }
}
