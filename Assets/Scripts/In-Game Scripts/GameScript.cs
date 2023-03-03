using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
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
        playerName = PlayerPrefs.GetString("PlayerName");
        playerClass = PlayerPrefs.GetString("PlayerClass");
        playerLevel = PlayerPrefs.GetInt("PlayerLevel");
        strength = PlayerPrefs.GetInt("Strength");
        dexterity = PlayerPrefs.GetInt("Dexterity");
        constitution = PlayerPrefs.GetInt("Constitution");
        intelligence = PlayerPrefs.GetInt("Intelligence");
        wisdom = PlayerPrefs.GetInt("Wisdom");
        
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
