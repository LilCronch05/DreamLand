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
    //string strength;
    //string dexterity;
    //string defence;
    //string health;
    //string speed;

    [SerializeField]
    GameObject nameField;

    [SerializeField]
    TextMeshProUGUI myText;


    string filePath = "SaveData";
    string fileName = "Save01.sav";

    SaveContainer myContainer = new SaveContainer();

    private void Start()
    {
        myText = nameField.GetComponentInChildren<TextMeshProUGUI>();
        LoadInfo();
        myText.text = myContainer.name;
    }

    public void ChangeName(string newName)
    {
        name = newName;
        SaveInfo();
    }
    /*
    public void ChangeStrength(string newStrength)
    {
        strength = newStrength;
    }
    public void ChangeDexterity(string newDexterity)
    {
        dexterity = newDexterity;
    }
    public void ChangeDefence(string newDefence)
    {
        defence = newDefence;
    }
    public void ChangeHealth(string newHealth)
    {
        health = newHealth;
    }
    public void ChangeSpeed(string newSpeed)
    {
        speed = newSpeed;
    }
    */

    public void SaveInfo()
    {
        myContainer.name = name;
        //myContainer.strength = strength;
        //myContainer.dexterity = dexterity;
        //myContainer.defence = defence;
        //myContainer.health = health;
        //myContainer.speed = speed;

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
    //public string strength; 
    //public string dexterity;
    //public string defence;
    //public string health;
    //public string speed;
}
