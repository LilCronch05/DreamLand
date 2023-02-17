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
    public GameObject characterInfo;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        characterInfo.SetActive(false);

        //This will show the name, class, and stats of the character made in the character creation scene
        playerName = myContainer.characterProfiles[myContainer.currentIndex].charName;
        playerLevel = myContainer.characterProfiles[myContainer.currentIndex].charLevel;
        strength = myContainer.characterProfiles[myContainer.currentIndex].charSTR;
        dexterity = myContainer.characterProfiles[myContainer.currentIndex].charDEX;
        constitution = myContainer.characterProfiles[myContainer.currentIndex].charCON;
        intelligence = myContainer.characterProfiles[myContainer.currentIndex].charINT;
        wisdom = myContainer.characterProfiles[myContainer.currentIndex].charWIS;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            characterInfo.SetActive(true);
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        characterInfo.SetActive(false);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
