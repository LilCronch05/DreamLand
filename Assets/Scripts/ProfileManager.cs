using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class ProfileManager : MonoBehaviour
{
    [SerializeField]
    InputField namefield;
    [SerializeField]
    Dropdown colorDrop, shapeDrop;
    [SerializeField]
    Material[] colors;
    [SerializeField]
    GameObject[] shapes;

    int profileIndex;

    [SerializeField]
    DataContainer2 myContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        myContainer = new DataContainer2();
        LoadData();
        if (myContainer.profiles.Count > 0)
        {
            profileIndex = 0;
        }
        else
        {
            profileIndex = -1;
        }     
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewProfile()
    {
        myContainer.AddProfile();
        profileIndex = myContainer.profiles.Count - 1;
        UpdateUI();
        SaveData();
    }

    public void DeleteProfile()
    {
        myContainer.RemoveProfile(profileIndex);
        if (profileIndex >= myContainer.profiles.Count)
        {
            profileIndex--;
        }
        if (profileIndex > -1)
        {
            UpdateUI();
        }
        SaveData();
    }

    public void UpdateProfile()
    {
        if (profileIndex > -1)
        {
            myContainer.profiles[profileIndex].name = namefield.text;
            myContainer.profiles[profileIndex].colorIndex = colorDrop.value;
            myContainer.profiles[profileIndex].shapeIndex = shapeDrop.value;
            SaveData();
            UpdateShape();
        }
    }

    void UpdateUI()
    {
        namefield.SetTextWithoutNotify(myContainer.profiles[profileIndex].name);
        colorDrop.SetValueWithoutNotify(myContainer.profiles[profileIndex].colorIndex);
        shapeDrop.SetValueWithoutNotify(myContainer.profiles[profileIndex].shapeIndex);

        UpdateShape();
    }

    public void NextProfile()
    {
        if (profileIndex < myContainer.profiles.Count - 1)
        {
            profileIndex++;
            UpdateUI();
        }   
    }

    public void PreviousProfile()
    {
        if (profileIndex > 0)
        {
            profileIndex--;
            UpdateUI();
        }
    }
    public void SaveData()
    {
        Stream stream = File.Open("Profiles2.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(DataContainer2));
        serializer.Serialize(stream, myContainer);
        stream.Close();
    }

    public void LoadData()
    {
        if (File.Exists("Profiles2.xml"))
        {
            Stream stream = File.Open("Profiles2.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(DataContainer2));
            myContainer = serializer.Deserialize(stream) as DataContainer2;
            stream.Close();
        }
    }

    void UpdateShape()
    {
        for (int i = 0;  i < shapes.Length; i++)
        {
            if (i == myContainer.profiles[profileIndex].shapeIndex)
            {
                shapes[i].SetActive(true);
                shapes[i].GetComponent<Renderer>().material = colors[myContainer.profiles[profileIndex].colorIndex];
            }
            else
            {
                shapes[i].SetActive(false);
            }
        }
    }
}
