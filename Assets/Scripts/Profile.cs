using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Profile
{
    public int charID;
    public string charName;
    public int charSTR;

    public Profile()
    {
        charID = 0;
        charName = "Name";
        charSTR = 0;
    }
}
