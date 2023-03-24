using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen, characterScreen, inventoryScreen;

    private void Start()
    {
        pauseScreen.SetActive(false);
        characterScreen.SetActive(false);
        inventoryScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (characterScreen.activeSelf)
            {
                characterScreen.SetActive(false);
            }
            else
            {
                characterScreen.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventoryScreen.activeSelf)
            {
                inventoryScreen.SetActive(false);
            }
            else
            {
                inventoryScreen.SetActive(true);
            }
        }
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        characterScreen.SetActive(false);
        inventoryScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
