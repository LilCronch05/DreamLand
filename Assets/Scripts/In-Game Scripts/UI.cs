using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen, characterScreen;

    private void Start()
    {
        pauseScreen.SetActive(false);
        characterScreen.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
            }
            else
            {
                pauseScreen.SetActive(true);
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
    }

    public void ContinueGame()
    {
        pauseScreen.SetActive(false);
        characterScreen.SetActive(false);
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
