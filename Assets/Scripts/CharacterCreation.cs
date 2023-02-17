using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CharacterCreation : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameField;
    [SerializeField]
    Slider strengthSlider;
    [SerializeField]
    Button[] profileButtons, classButtons;
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
            strengthSlider.interactable = false;
        }
        else
        {
            nameField.interactable = true;
            strengthSlider.interactable = true;

            nameField.text = "";
            strengthSlider.value = 0;
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
        strengthSlider.value = DataManager1.dmInstance.myProfile.charSTR;
    }

    public void DoneEditting()
    {
        profileButtons[DataManager1.dmInstance.myProfile.charID].GetComponentInChildren<TextMeshProUGUI>().text = DataManager1.dmInstance.myProfile.charName;
        DataManager1.dmInstance.SaveProfile(DataManager1.dmInstance.myProfile.charID);
    }
}
