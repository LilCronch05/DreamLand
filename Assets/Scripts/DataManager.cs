using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

// This script is used to save and load character and area data.
public class DataManager : MonoBehaviour
{
    public static DataManager dmInstance = null;

    public string rootPath = "SaveData";

    private void Awake()
    {
        if (dmInstance == null)
        {
            dmInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (dmInstance != this)
        {
            Destroy(gameObject);
        }

        if (!Directory.Exists(DataManager.dmInstance.rootPath))
        {
            Directory.CreateDirectory(DataManager.dmInstance.rootPath);
        }
    }
    
    // This method will save the CharacterData passed in by reference for the profile using the index passed in
    public void SaveData(ref CharacterData data, int index)
    {
        if (!Directory.Exists(DataManager.dmInstance.rootPath + "/Profile" + index))
        {
            Directory.CreateDirectory(DataManager.dmInstance.rootPath + "/Profile" + index);
        }

        Stream stream = File.Open(rootPath + "/Profile" + index + "/CharacterData.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterData));
        serializer.Serialize(stream, data);
        stream.Close();
    }

    // This method will save the AreaData passed in by reference for the profile using the index passed in
    public void SaveData(ref AreaData data, int index)
    {
        if (!Directory.Exists(DataManager.dmInstance.rootPath + "/Profile" + index))
        {
            Directory.CreateDirectory(DataManager.dmInstance.rootPath + "/Profile" + index);
        }

        Stream stream = File.Open(rootPath + "/Profile" + index + "/Area" + data.areaID + ".xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(AreaData));
        serializer.Serialize(stream, data);
        stream.Close();
    }

    // This method will load the CharacterData passed in by reference for the profile using the index passed in
    public bool LoadData(ref CharacterData data, int index)
    {
        bool returnCode = false;

        if (File.Exists(DataManager.dmInstance.rootPath + "/Profile" + index + "/CharacterData.xml"))
        {
            Stream stream = File.Open(rootPath + "/Profile" + index + "/CharacterData.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CharacterData));
            data = (CharacterData)serializer.Deserialize(stream);
            stream.Close();

            returnCode = true;
        }

        return returnCode;
    }

    // This method will load the AreaData passed in by reference for the profile using the index passed in
    public bool LoadData(ref AreaData data, int index)
    {
        bool returnCode = false;

        if (File.Exists(DataManager.dmInstance.rootPath + "/Profile" + index + "/CharacterData.xml"))
        {
            Stream stream = File.Open(rootPath + "/Profile" + index + "/Area" + data.areaID + ".xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(AreaData));
            data = (AreaData)serializer.Deserialize(stream);
            stream.Close();

            returnCode = true;
        }

        return returnCode;
    }

    public void RemoveCharacter(int index)
    {
        File.Delete(rootPath + "/Profile" + index + "/CharacterData.xml");
    }
}
