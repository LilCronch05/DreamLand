using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    SaveContainer myContainer;
    public string playerName;
    public string playerClass;
    public int playerLevel;
    public int strength;
    public int dexterity;
    public int constitution;
    public int intelligence;
    public int wisdom;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);

        //This will show the name, class, and stats of the character made in the character creation scene
        playerName = myContainer.characterProfiles[myContainer.currentIndex].characterName;
        playerLevel = myContainer.characterProfiles[myContainer.currentIndex].characterLevel;
        strength = myContainer.characterProfiles[myContainer.currentIndex].characterStrength;
        dexterity = myContainer.characterProfiles[myContainer.currentIndex].characterDexterity;
        constitution = myContainer.characterProfiles[myContainer.currentIndex].characterConstitution;
        intelligence = myContainer.characterProfiles[myContainer.currentIndex].characterIntelligence;
        wisdom = myContainer.characterProfiles[myContainer.currentIndex].characterWisdom;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
