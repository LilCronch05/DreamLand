using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;
using TMPro;

public class SaveLoad : MonoBehaviour
{
    //CLick Counter Variables
    public bool gameStarted;

    public TextMeshProUGUI labelText;
    public TextMeshProUGUI timerText;
    public GameObject startButton;
    public GameObject scoreButton;

    //SaveLoad Variables
    [SerializeField]
    string name;
    int score;
    int timer = 10;

    [SerializeField]
    GameObject nameField;

    [SerializeField]
    TextMeshProUGUI myText, scoreText, highScoreText;
    


    string filePath = "SaveData";
    string fileName = "Save01.sav";

    SaveContainer myContainer = new SaveContainer();

    
    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        //timerText.text = timer.ToString();

        myText = nameField.GetComponentInChildren<TextMeshProUGUI>();
        LoadInfo();
        myText.text = myContainer.name;
        highScoreText.text = "High Score: " + myContainer.score.ToString();
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

    //SAVELOAD METHODS
    //Save the name
    public void ChangeName(string newName)
    {
        name = newName;
        SaveInfo();
    }
    //Save the score
    public void SaveScore(int newScore)
    {
        score = newScore;
        SaveInfo();
    }

    public void SaveInfo()
    {
        myContainer.name = name;
        myContainer.score = score;

        if(!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        Stream stream = File.Open(filePath + "/" + fileName, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        serializer.Serialize(stream, myContainer);
        stream.Close();
    }

    public void LoadInfo()
    {
        if(Directory.Exists(filePath))
        {
            Stream stream = File.Open(filePath + "/" + fileName, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
            myContainer = (SaveContainer)serializer.Deserialize(stream);
            stream.Close();
        }
    }
}

[System.Serializable]
public class SaveContainer
{
    public string name;
    public int score; 
}