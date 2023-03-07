using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField] TMP_InputField nameField;
    [SerializeField] TextMeshProUGUI STRText, DEXText, CONText, INTText, WISText, TotalStatText;
    [SerializeField] Slider strengthSlider, dexteritySlider, constitutionSlider, intelligenceSlider, wisdomSlider;
    [SerializeField] Button[] profileButtons;
    [SerializeField] Button[] classButtons;
    [SerializeField] GameObject confirmationPanel, doneButton, deleteButton, yesButton, noButton;

    GameData myCharacter;
    StatManager statManager;

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = new GameData();

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

            if(index == 0)
            {
                doneButton.SetActive(true);
            }
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

    public void ChooseProfileClass(int classIndex)
    {
        myCharacter.charClass = (int)classIndex;
    }
    
    public void ChangeProfileConstitution(float value)
    {
        myCharacter.charCON = (int)value;
    }

    public void ChangeProfileStrength(float value)
    {
        myCharacter.charSTR = (int)value;
    }

    public void ChangeProfileDexterity(float value)
    {
        myCharacter.charDEX = (int)value;
    }

    public void ChangeProfileIntelligence(float value)
    {
        myCharacter.charINT = (int)value;
    }

    public void ChangeProfileWisdom(float value)
    {
        myCharacter.charWIS = (int)value;
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
        myCharacter.charName = nameField.text;
        myCharacter.charSTR = (int)strengthSlider.value;
        myCharacter.charDEX = (int)dexteritySlider.value;
        myCharacter.charCON = (int)constitutionSlider.value;
        myCharacter.charINT = (int)intelligenceSlider.value;
        myCharacter.charWIS = (int)wisdomSlider.value;

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
        
        myCharacter = new GameData();
        profileButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = myCharacter.charName;
        confirmationPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        confirmationPanel.SetActive(false);
    }

    public void StartGame()
    {
        DataManager.dmInstance.SaveData(ref myCharacter, myCharacter.charID);
        //SceneManager.LoadScene("Field1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Slider value changed
    public void OnSliderValueChanged()
    {
        int total = (int)strengthSlider.value + (int)dexteritySlider.value + (int)constitutionSlider.value + (int)intelligenceSlider.value + (int)wisdomSlider.value;

        if (total > 50)
        {
            strengthSlider.value = strengthSlider.value - 1;
            dexteritySlider.value = dexteritySlider.value - 1;
            constitutionSlider.value = constitutionSlider.value - 1;
            intelligenceSlider.value = intelligenceSlider.value - 1;
            wisdomSlider.value = wisdomSlider.value - 1;
        }
        TotalStatText.text = "Used Stat Points: " + total.ToString();

        STRText.text = "STR: " + strengthSlider.value.ToString();
        DEXText.text = "DEX: " + dexteritySlider.value.ToString();
        CONText.text = "CON: " + constitutionSlider.value.ToString();
        INTText.text = "INT: " + intelligenceSlider.value.ToString();
        WISText.text = "WIS: " + wisdomSlider.value.ToString();
    }
}
