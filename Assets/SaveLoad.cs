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
    [SerializeField]
    string name;
    int score;

    [SerializeField]
    GameObject nameField;
    GameObject scoreCounter;

    [SerializeField]
    TextMeshProUGUI myText, scoreText, highScoreText;
    


    string filePath = "SaveData";
    string fileName = "Save01.sav";

    SaveContainer myContainer = new SaveContainer();

    private void Start()
    {
        myText = nameField.GetComponentInChildren<TextMeshProUGUI>();
        highScoreText = scoreCounter.GetComponent<TextMeshProUGUI>();
        LoadInfo();
        myText.text = myContainer.name;
        highScoreText.text = "High Score: " + myContainer.score.ToString();
    }

    private void Update()
    {
        /*
        if (nameField == "")
        {
            GetComponent<ClickCounter>().Button.SetActive = false;
        }
        */
    }

    public void ChangeName(string newName)
    {
        name = newName;
        SaveInfo();
    }
    public void SaveScore(int newScore)
    {
        score = newScore;
        if (newScore >= score)
        {
            SaveInfo();
        }
        
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
