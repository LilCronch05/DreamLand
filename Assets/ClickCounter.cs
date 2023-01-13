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
    public int score;

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
        }
    }

    public void StartGame()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameStarted = true;
        }
    }
    /*
    IEnumerable StartGameTimer()
    {
        
    }
    */
}
