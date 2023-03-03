using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] TMP_InputField nameField;
    [SerializeField] Slider strengthSlider, dexteritySlider, constitutionSlider, intelligenceSlider, wisdomSlider;
    [SerializeField] Button[] profileButtons;
    [SerializeField] GameObject newProfilePanel, confirmationPanel, doneButton, deleteButton, yesButton, noButton;

    CharacterData myCharacter;    

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = new CharacterData();

        for (int i = 0; i < profileButtons.Length; i++)
        {
            if (DataManager.dmInstance.LoadData(ref myCharacter, i))
            {
                profileButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = myCharacter.charName;
            }
        }
    }

    public void SelectProfile(int index)
    {
        myCharacter.charID = index;
        newProfilePanel.SetActive(true);

        

        if (DataManager.dmInstance.LoadData(ref myCharacter, index))
        {
            
            UpdateProfileUI();

            nameField.interactable = false;
            strengthSlider.interactable = false;
            dexteritySlider.interactable = false;
            constitutionSlider.interactable = false;
            intelligenceSlider.interactable = false;
            wisdomSlider.interactable = false;
            doneButton.SetActive(false);
            deleteButton.SetActive(true);
        }
        else
        {
            nameField.interactable = true;
            strengthSlider.interactable = true;
            dexteritySlider.interactable = true;
            constitutionSlider.interactable = true;
            intelligenceSlider.interactable = true;
            wisdomSlider.interactable = true;
            doneButton.SetActive(true);
            deleteButton.SetActive(false);

            nameField.text = "";
            strengthSlider.value = 0;
            dexteritySlider.value = 0;
            constitutionSlider.value = 0;
            intelligenceSlider.value = 0;
            wisdomSlider.value = 0;
        }
    }
    public void ChangeProfileName(string name)
    {
        myCharacter.charName = name;
    }

    // public void ChooseProfileClass(int classIndex)
    // {
    //     myCharacter.charClass = (int)classIndex;
    // }

    public void ChangeProfileStrength(float value)
    {
        myCharacter.charSTR = (int)value;
    }

    public void ChangeProfileDexterity(float value)
    {
        myCharacter.charDex = (int)value;
    }

    void UpdateProfileUI()
    {
        nameField.text = myCharacter.charName;
        strengthSlider.value = myCharacter.charSTR;
        dexteritySlider.value = myCharacter.charDEX;
        constitutionSlider.value = myCharacter.charCON;
        intelligenceSlider.value = myCharacter.charINT;
        wisdomSlider.value = myCharacter.charWIS;
    }

    public void DoneEditting()
    {
        profileButtons[myCharacter.charID].GetComponentInChildren<TextMeshProUGUI>().text = myCharacter.charName;
        DataManager.dmInstance.SaveData(ref myCharacter, myCharacter.charID);
    }

    public void ConfirmDelete()
    {
        confirmationPanel.SetActive(true);
    }

    public void DeleteProfile()
    {
        int index = myCharacter.charID;
        DataManager.dmInstance.RemoveCharacter(index);
        
        myCharacter = new CharacterData();
        profileButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = myCharacter.charName;
        confirmationPanel.SetActive(false);
        newProfilePanel.SetActive(false);
    }

    public void CancelDelete()
    {
        confirmationPanel.SetActive(false);
    }
}
