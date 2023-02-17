using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

// This script is used to save and load profile information including character and area data.
public class DataManager1 : MonoBehaviour
{
    public static DataManager1 dmInstance = null;

    public CharacterProfile myProfile;

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

        if (!Directory.Exists(DataManager1.dmInstance.rootPath))
        {
            Directory.CreateDirectory(DataManager1.dmInstance.rootPath);
        }
    }
    
    public void SaveProfile(int index)
    {
        if (!Directory.Exists(DataManager1.dmInstance.rootPath + "/Profile" + index))
        {
            Directory.CreateDirectory(DataManager1.dmInstance.rootPath + "/Profile" + index);
        }

        Stream stream = File.Open(rootPath + "/Profile" + myProfile.charID + "/CharacterData.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterProfile));
        serializer.Serialize(stream, myProfile);
        stream.Close();
    }

    public bool LoadProfile(int index)
    {
        bool returnCode = false;

        if (File.Exists(DataManager1.dmInstance.rootPath + "/Profile" + index + "/CharacterData.xml"))
        {
            Stream stream = File.Open(rootPath + "/Profile" + index + "/CharacterData.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(CharacterProfile));
            myProfile = (CharacterProfile)serializer.Deserialize(stream);
            stream.Close();

            returnCode = true;
        }

        return returnCode;
    }
}
