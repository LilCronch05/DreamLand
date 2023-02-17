using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CraracterCreation : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameField;
    [SerializeField]
    Slider strengthSlider;
    [SerializeField]
    Button[] profileButtons;
    [SerializeField]
    GameObject newProfilePanel;

    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < profileButtons.Length; i++)
        {
            if (DataManager.dmInstance.LoadProfile(i))
            {
                profileButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = DataManager.dmInstance.myProfile.charName;
            }
        }
    }

    public void SelectProfile(int index)
    {
        DataManager.dmInstance.myProfile.charID = index;
        newProfilePanel.SetActive(true);

        

        if (DataManager.dmInstance.LoadProfile(index))
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
        DataManager.dmInstance.myProfile.charName = name;
    }

    public void ChangeProfileStrength(float value)
    {
        DataManager.dmInstance.myProfile.charSTR = (int)value;
    }

    void UpdateProfileUI()
    {
        nameField.text = DataManager.dmInstance.myProfile.charName;
        strengthSlider.value = DataManager.dmInstance.myProfile.charSTR;
    }

    public void DoneEditting()
    {
        profileButtons[DataManager.dmInstance.myProfile.charID].GetComponentInChildren<TextMeshProUGUI>().text = DataManager.dmInstance.myProfile.charName;
        DataManager.dmInstance.SaveProfile(DataManager.dmInstance.myProfile.charID);
    }
}
