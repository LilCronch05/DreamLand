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
        characterProfiles.Add(new CharacterProfile("Profile " + (characterProfiles.Count + 1).ToString(), 0, 50, 1, 0, 0, 0, 0, 0, 0));
    }
    public void RemoveProfile(int index)
    {
        characterProfiles.RemoveAt(index);
    }
}
