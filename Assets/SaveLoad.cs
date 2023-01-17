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
    

    //SaveLoad Variables
    [SerializeField]
    string name;
    public int score;

    [SerializeField]
    public GameObject nameField;

    [SerializeField]
    public TextMeshProUGUI myText, scoreText, highScoreText;

    TextMeshProUGUI[] LeaderBoard;
    


    string filePath = "SaveData";
    string fileName = "Save01.sav";

    SaveContainer myContainer = new SaveContainer();

    
    // Start is called before the first frame update
    void Start()
    {
        myText = nameField.GetComponentInChildren<TextMeshProUGUI>();
        LoadInfo();
        myText.text = myContainer.name;
        highScoreText.text = "High Score: " + myContainer.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
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