using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class ClickCounter : MonoBehaviour
{
    //CLick Counter Variables
    public bool gameStarted;

    public TextMeshProUGUI labelText;
    public TextMeshProUGUI timerText;
    public GameObject startButton;
    public GameObject scoreButton;

    int timer = 10;
    
    //SaveLoad
    public int score;
    GameObject nameField;
    TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        //timerText.text = timer.ToString();
        score = GetComponent<SaveLoad>().score;
        nameField = GetComponent<SaveLoad>().nameField;
        scoreText = GetComponent<SaveLoad>().scoreText;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            //nameField.enabled = false;
            startButton.SetActive(false);
            scoreButton.SetActive(true);

            labelText.text = "GO";

            StartCoroutine(Timer());
            if (timer <= 0)
            {
                labelText.text = "Done";
                scoreButton.SetActive(false);
                gameStarted = false;
            }
        }
        else
        {
            startButton.SetActive(true);
            scoreButton.SetActive(false);
        }
    }

    //Click Counter Methods
    public void AddScore()
    {
        score += 1;
        scoreText.text = "Your Score: " + score.ToString();
    }

    public void StartGame()
    {
        if (nameField.GetComponentInChildren<TextMeshProUGUI>().text != "")
        {
            gameStarted = true;
        }
    }

    // Enumerator for the timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        timer -= 1;
    }
}
