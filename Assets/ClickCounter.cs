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

    public GameObject Button;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();

        if(gameStarted)
        {
            Button.SetActive(false);

            labelText.text = "GO";

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                score += 1;
                scoreText.text = "Your Score: " + score.ToString();
            }

            StartCoroutine(Timer());

            if (timer <= 0)
            {
                labelText.text = "Done";
                timerText.text = "0";
                Button.SetActive(true);
                gameStarted = false;
            }
        }
        else
        {
            scoreText.text = "Your Score: 0";
            timerText.text = "10";
            score = 0; //score is unable to grow if game is not started
        }
    }

    public void StartGame()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameStarted = true;
        }
    }
    
    // Enumerator for the timer
    IEnumerator Timer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(10);
            timerText.text = timer.ToString();
            timer -= 1;
        }
    }
}
