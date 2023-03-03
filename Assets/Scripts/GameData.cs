// These are the classes that store the data for the player character, areas, etc.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public int charID;
    public string charName;
    public int charSTR;

    public CharacterData()
    {
        charID = 0;
        charName = "Empty";
        charSTR = 0;
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
