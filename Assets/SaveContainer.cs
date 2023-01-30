using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveContainer : MonoBehaviour
{
    public List<CharacterProfile> characterProfiles;
    public int currentIndex;

    public SaveContainer()
    {
        characterProfiles = new List<CharacterProfile>();
    }
    public void AddProfile()
    {
        characterProfiles.Add(new CharacterProfile());
    }
    public void RemoveProfile(int index)
    {
        characterProfiles.RemoveAt(index);
    }
}
