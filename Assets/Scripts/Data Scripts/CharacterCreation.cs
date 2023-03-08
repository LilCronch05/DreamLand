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


    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < profileButtons.Length; i++)
        {
            if (DataManager.dmInstance.LoadData(ref GameManager.gmInstance.gameData, i))
            {
                profileButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gmInstance.gameData.charName;
            }
        }
    }

    public void SelectProfile(int index)
    {
        GameManager.gmInstance.gameData.charID = index;

        if (DataManager.dmInstance.LoadData(ref GameManager.gmInstance.gameData, index))
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
        GameManager.gmInstance.gameData.charName = name;
    }

    public void ChooseProfileClass(int classIndex)
    {
        GameManager.gmInstance.gameData.charClass = (int)classIndex;
    }
    
    public void ChangeProfileConstitution(float value)
    {
        GameManager.gmInstance.gameData.charCON = (int)value;
    }

    public void ChangeProfileStrength(float value)
    {
        GameManager.gmInstance.gameData.charSTR = (int)value;
    }

    public void ChangeProfileDexterity(float value)
    {
        GameManager.gmInstance.gameData.charDEX = (int)value;
    }

    public void ChangeProfileIntelligence(float value)
    {
        GameManager.gmInstance.gameData.charINT = (int)value;
    }

    public void ChangeProfileWisdom(float value)
    {
        GameManager.gmInstance.gameData.charWIS = (int)value;
    }

    void UpdateProfileUI()
    {
        nameField.text = GameManager.gmInstance.gameData.charName;
        strengthSlider.value = GameManager.gmInstance.gameData.charSTR;
        dexteritySlider.value = GameManager.gmInstance.gameData.charDEX;
        constitutionSlider.value = GameManager.gmInstance.gameData.charCON;
        intelligenceSlider.value = GameManager.gmInstance.gameData.charINT;
        wisdomSlider.value = GameManager.gmInstance.gameData.charWIS;
    }

    public void DoneEditting()
    {
        GameManager.gmInstance.gameData.charName = nameField.text;
        GameManager.gmInstance.gameData.charSTR = (int)strengthSlider.value;
        GameManager.gmInstance.gameData.charDEX = (int)dexteritySlider.value;
        GameManager.gmInstance.gameData.charCON = (int)constitutionSlider.value;
        GameManager.gmInstance.gameData.charINT = (int)intelligenceSlider.value;
        GameManager.gmInstance.gameData.charWIS = (int)wisdomSlider.value;

        profileButtons[GameManager.gmInstance.gameData.charID].GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gmInstance.gameData.charName;
        DataManager.dmInstance.SaveData(ref GameManager.gmInstance.gameData, GameManager.gmInstance.gameData.charID);
    }

    public void ConfirmDelete()
    {
        confirmationPanel.SetActive(true);
    }

    public void DeleteProfile()
    {
        int index = GameManager.gmInstance.gameData.charID;
        DataManager.dmInstance.RemoveCharacter(index);
        
        GameManager.gmInstance.gameData = new GameData();
        profileButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = GameManager.gmInstance.gameData.charName;
        confirmationPanel.SetActive(false);
    }

    public void CancelDelete()
    {
        confirmationPanel.SetActive(false);
    }

    public void StartGame()
    {
        DataManager.dmInstance.SaveData(ref GameManager.gmInstance.gameData, GameManager.gmInstance.gameData.charID);
        SceneManager.LoadScene("Field1");
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
