using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class ClickCounter : MonoBehaviour
{
    public bool gameStarted;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI timerText;
    public int score;
    public int timer = 10;

    public GameObject startButton;
    public GameObject scoreButton;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        //timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted)
        {
            startButton.SetActive(false);
            scoreButton.SetActive(true);

            labelText.text = "GO";

            StartCoroutine(Timer());
            if (timer <= 0)
            {
                labelText.text = "Done";
                gameStarted = false;
                scoreButton.SetActive(false);
            }
        }
        else
        {
            startButton.SetActive(true);
            scoreButton.SetActive(false);
        }
    }

    public void AddScore()
    {
        score += 1;
        scoreText.text = "Your Score: " + score.ToString();
    }

    public void StartGame()
    {
        gameStarted = true;
    }
    
    // Enumerator for the timer
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        timer -= 1;
    }
}
