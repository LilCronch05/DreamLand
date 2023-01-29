using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;

public class DataManager : MonoBehaviour
{
    public SaveContainer myContainer;

    public Button[] profileButtons;
    public Button[] classButtons;
    public Button resetButton;

    public InputField characterName;
    public TextMeshProUGUI statPoints;
    public TextMeshProUGUI characterLevel;
    public int index;

    void Start()
    {
        myContainer = new SaveContainer();
        LoadData();
        index = -1;
        classButtons[0].interactable = false;

    }

    public void LoadData()
    {
        if (File.Exists("SaveData/Profiles.xml"))
        {
            FileStream stream = File.Open("SaveFiles/Profiles.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
            myContainer = serializer.Deserialize(stream) as SaveContainer;
            stream.Close();
        }

        UpdateProfileButtons();
    }

    public void SaveData()
    {
        FileStream stream = File.Open("SaveFiles/Profiles.xml", FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
        serializer.Serialize(stream, myContainer);
        stream.Close();
    }

    public void SelectProfile(int buttonIndex)
    {
        // If the profile button pressed does not yet have a profile associated with it then add a new profile.
        if (buttonIndex > myContainer.characterProfiles.Count - 1)
        {
            myContainer.AddProfile();
            index = myContainer.characterProfiles.Count - 1;
            myContainer.currentIndex = index;

            UpdateProfileButtons();
        }
        else
        {
            index = buttonIndex;
            myContainer.currentIndex = index;
        }
        characterName.text = myContainer.characterProfiles[index].GetCharacterName();
        statPoints.text = myContainer.characterProfiles[index].GetCharacterStatPoints().ToString();
        characterLevel.text = myContainer.characterProfiles[index].GetCharacterLevel().ToString();
        classButtons[myContainer.characterProfiles[index].GetCharacterClass()].Select();

        resetButton.interactable = true;
    }

    public void ClearProfile()
    {
        if (index < myContainer.characterProfiles.Count)
        {
            // Clear the profile data.
            myContainer.characterProfiles[index].SetCharacterName("Profile " + (index + 1).ToString());
            myContainer.characterProfiles[index].SetCharacterStatPoints(50);
            myContainer.characterProfiles[index].SetCharacterLevel(1);
            myContainer.characterProfiles[index].SetCharacterClass(0);
            myContainer.characterProfiles[index].SetCharacterStrength(0);
            myContainer.characterProfiles[index].SetCharacterDexterity(0);
            myContainer.characterProfiles[index].SetCharacterConstitution(0);
            myContainer.characterProfiles[index].SetCharacterIntelligence(0);
            myContainer.characterProfiles[index].SetCharacterWisdom(0);

            SaveData();
        }
    }

    void UpdateProfileButtons()
    {
        // Set all of the profile buttons active state to false.
        for (int i = 0; i < profileButtons.Length; i++)
        {
            profileButtons[i].gameObject.SetActive(false);
        }

        // For each loaded profile activate the profile button and change the text to the name of the profile.
        for (int i = 0; i < myContainer.characterProfiles.Count; i++)
        {
            profileButtons[i].gameObject.SetActive(true);
            profileButtons[i].GetComponentInChildren<Text>().text = myContainer.characterProfiles[i].GetCharacterName();
        }

        // If the number of profiles loaded is less than the profile buttons available then activate the next
        // profile button and set the text to "Add Profile".
        if (myContainer.characterProfiles.Count < 5)
        {
            profileButtons[myContainer.characterProfiles.Count].gameObject.SetActive(true);
            profileButtons[myContainer.characterProfiles.Count].GetComponentInChildren<Text>().text = "Add Profile";
        }

        if (myContainer.characterProfiles.Count == 0)
        {
            characterName.interactable = false;
            classButtons[0].interactable = false;
        }
        else
        {
            characterName.interactable = true;
            classButtons[0].interactable = true;
        }
        SaveData();
    }

    public void ChangeName(string changeName)
    {
        myContainer.characterProfiles[index].SetCharacterName(changeName);
        UpdateProfileButtons();
    }
    public void ChangeClass(int changeClass)
    {
        myContainer.characterProfiles[index].SetCharacterClass(changeClass);
        UpdateProfileButtons();
    }
    public void ChangeStatPoints(int changeStatPoints)
    {
        myContainer.characterProfiles[index].SetCharacterStatPoints(changeStatPoints);
        UpdateProfileButtons();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
