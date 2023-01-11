using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEditor.UI;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    string name;
    string strength;
    string dexterity;
    string defence;
    string health;
    string speed;


    string filePath = "SaveData";
    string fileName = "Save01.sav";

    SaveContainer myContainer = new SaveContainer();

    public void ChangeName(string newName)
    {
        name = newName;
    }
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

    public void SaveInfo()
    {
        myContainer.name = name;
        myContainer.strength = strength;
        myContainer.dexterity = dexterity;
        myContainer.defence = defence;
        myContainer.health = health;
        myContainer.speed = speed;

        if(!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        Stream stream = File.Open(filePath + "/" + fileName, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        serializer.Serialize(stream, myContainer);
        stream.Close();
    }
}

[System.Serializable]
public class SaveContainer
{
    public string name;
    public string strength; 
    public string dexterity;
    public string defence;
    public string health;
    public string speed;
}
