using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameField;
    [SerializeField]
    Button[] profileButtons, classButtons, increaseStatButtons, decreaseStatButtons;
    [SerializeField]
    GameObject newProfilePanel;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < profileButtons.Length; i++)
        {
            if (DataManager1.dmInstance.LoadProfile(i))
            {
                profileButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = DataManager1.dmInstance.myProfile.charName;
            }
        }
    }

    public void SelectProfile(int index)
    {
        DataManager1.dmInstance.myProfile.charID = index;
        newProfilePanel.SetActive(true);

        

        if (DataManager1.dmInstance.LoadProfile(index))
        {
            
            UpdateProfileUI();

            nameField.interactable = false;
        }
        else
        {
            nameField.interactable = true;

            nameField.text = "";
        }
    }
    public void ChangeProfileName(string name)
    {
        DataManager1.dmInstance.myProfile.charName = name;
    }

    public void ChangeProfileStrength(float value)
    {
        DataManager1.dmInstance.myProfile.charSTR = (int)value;
    }

    void UpdateProfileUI()
    {
        nameField.text = DataManager1.dmInstance.myProfile.charName;
    }

    public void DoneEditting()
    {
        profileButtons[DataManager1.dmInstance.myProfile.charID].GetComponentInChildren<TextMeshProUGUI>().text = DataManager1.dmInstance.myProfile.charName;
        DataManager1.dmInstance.SaveProfile(DataManager1.dmInstance.myProfile.charID);
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
