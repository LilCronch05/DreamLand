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
    // //SaveContainer myContainer;

    // [SerializeField]
    // Button[] profileButtons, classButtons;
    // [SerializeField]
    // TMP_InputField characterName;
    
    // public Button resetButton;
    // public TextMeshProUGUI statPoints, characterLevel;
    // public int index;

    // void Start()
    // {
    //     myContainer = new SaveContainer();
    //     //LoadData();
    //     if (myContainer.characterProfiles.Count > 0)
    //     {
    //         index = 0;
    //     }
    //     else
    //     {
    //         index = -1;
    //     }
    //     UpdateProfileButtons();
    // }

    // public void ClearProfile()
    // {
    //     if (index < myContainer.characterProfiles.Count)
    //     {
    //         myContainer.characterProfiles.RemoveAt(index);
           
    //         // Clear the profile data.
    //         myContainer.characterProfiles[index].SetCharacterName("Profile " + (index + 1));
    //         myContainer.characterProfiles[index].SetCharacterStatPoints(50);
    //         myContainer.characterProfiles[index].SetCharacterLevel(1);
    //         myContainer.characterProfiles[index].SetCharacterClass(0);
    //         myContainer.characterProfiles[index].SetCharacterStrength(0);
    //         myContainer.characterProfiles[index].SetCharacterDexterity(0);
    //         myContainer.characterProfiles[index].SetCharacterConstitution(0);
    //         myContainer.characterProfiles[index].SetCharacterIntelligence(0);
    //         myContainer.characterProfiles[index].SetCharacterWisdom(0);

    //         UpdateProfileButtons();
    //     }
    // }

    // void UpdateProfileButtons()
    // {
    //     // Set all of the profile buttons active state to false.
    //     for (int i = 0; i < profileButtons.Length; i++)
    //     {
    //         profileButtons[i].gameObject.SetActive(false);
    //     }

    //     // For each loaded profile activate the profile button and change the text to the name of the profile.
    //     for (int i = 0; i < myContainer.characterProfiles.Count; i++)
    //     {
    //         profileButtons[i].gameObject.SetActive(true);
    //         profileButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = myContainer.characterProfiles[i].GetCharacterName();
    //     }

    //     // If the number of profiles loaded is less than the profile buttons available then activate the next
    //     // profile button and set the text to "Add Profile".
    //     if (myContainer.characterProfiles.Count < 4)
    //     {
    //         profileButtons[myContainer.characterProfiles.Count].gameObject.SetActive(true);
    //         profileButtons[myContainer.characterProfiles.Count].GetComponentInChildren<TextMeshProUGUI>().text = "Add Profile";
    //     }
    // }   

    // public void SelectProfile(int buttonIndex)
    // {
    //     // If the profile button pressed does not yet have a profile associated with it then add a new profile.
    //     if (buttonIndex > myContainer.characterProfiles.Count - 1)
    //     {
    //         myContainer.AddProfile();
    //         index = myContainer.characterProfiles.Count - 1;
    //         myContainer.currentIndex = index;

    //         //ClearProfile();
    //         UpdateProfileButtons();
    //     }
    //     else
    //     {
    //         index = buttonIndex;
    //         myContainer.currentIndex = index;
    //     }
    //     //characterName.text = myContainer.characterProfiles[index].GetCharacterName();
    //     statPoints.text = myContainer.characterProfiles[index].GetCharacterStatPoints().ToString();
    //     characterLevel.text = myContainer.characterProfiles[index].GetCharacterLevel().ToString();
    //     classButtons[myContainer.characterProfiles[index].GetCharacterClass()].Select();

    //     resetButton.interactable = true;
    // }

    // public void SaveData(int index)
    // {
    //     Stream stream = File.Open("SaveData/Profile/CharacterData.xml" + index, FileMode.Create);
    //     XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
    //     serializer.Serialize(stream, myContainer);
    //     stream.Close();
    // }
    
    // public void LoadData(int index)
    // {
    //     Stream stream = File.Open("SaveData/Profile/CharacterData.xml" + index, FileMode.Open);
    //     XmlSerializer serializer = new XmlSerializer(typeof(SaveContainer));
    //     myContainer = (SaveContainer)serializer.Deserialize(stream);
    //     stream.Close();
    // }

    // public void ChangeName(string changeName)
    // {
    //     myContainer.characterProfiles[index].SetCharacterName(changeName);
    //     UpdateProfileButtons();
    // }
    // public void ChangeClass(int changeClass)
    // {
    //     myContainer.characterProfiles[index].SetCharacterClass(changeClass);
    //     UpdateProfileButtons();
    // }
    // public void ChangeStatPoints(int changeStatPoints)
    // {
    //     myContainer.characterProfiles[index].SetCharacterStatPoints(changeStatPoints);
    //     UpdateProfileButtons();
    // }

    // public void PlayGame()
    // {
    //     SceneManager.LoadScene(1);
    // }

    // public void ExitGame()
    // {
    //     Application.Quit();
    // }
}
