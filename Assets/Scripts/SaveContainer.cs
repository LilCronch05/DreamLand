using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveContainer
{
    public List<CharacterProfile> characterProfiles;
    public int currentIndex;

    public SaveContainer()
    {
        characterProfiles = new List<CharacterProfile>();
    }
    public void AddProfile()
    {
        characterProfiles.Add(new CharacterProfile("Profile " + (characterProfiles.Count + 1), 0, 50, 1, 0, 0, 0, 0, 0, 0));
    }
    public void RemoveProfile(int index)
    {
        characterProfiles.RemoveAt(index);
    }
}
