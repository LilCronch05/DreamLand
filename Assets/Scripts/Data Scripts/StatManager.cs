using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatManager : MonoBehaviour
{
    //This is the script that will be used to manage the stats of the character. 
    //  Any of the stats set in the menu will be used to set the stats of the character.

    [SerializeField]
    private TextMeshProUGUI m_LevelText, m_ConstitutionText, m_StrengthText, m_DexterityText, m_IntelligenceText, m_WisdomText, m_NameText;

    private void Start()
    {
        m_LevelText.text = "Level: " + GameManager.gmInstance.gameData.charLevel.ToString();
        m_ConstitutionText.text = "CON: " + GameManager.gmInstance.gameData.charCON.ToString();
        m_StrengthText.text = "STR: " + GameManager.gmInstance.gameData.charSTR.ToString();
        m_DexterityText.text = "DEX: " + GameManager.gmInstance.gameData.charDEX.ToString();
        m_IntelligenceText.text = "INT: " + GameManager.gmInstance.gameData.charINT.ToString();
        m_WisdomText.text = "WIS: " + GameManager.gmInstance.gameData.charWIS.ToString();

        m_NameText.text = GameManager.gmInstance.gameData.charName;
    }

    public void IncreaseStat(string stat)
    {
        switch (stat)
        {
            case "Level":
                GameManager.gmInstance.gameData.charLevel += 1;
                m_LevelText.text = "Level: " + GameManager.gmInstance.gameData.charLevel.ToString();
                break;
            case "CON":
                GameManager.gmInstance.gameData.charCON += 2;
                m_ConstitutionText.text = "CON: " + GameManager.gmInstance.gameData.charCON.ToString();
                break;
            case "STR":
                GameManager.gmInstance.gameData.charSTR += 5;
                m_StrengthText.text = "STR: " + GameManager.gmInstance.gameData.charSTR.ToString();
                break;
            case "DEX":
                GameManager.gmInstance.gameData.charDEX += 5;
                m_DexterityText.text = "DEX: " + GameManager.gmInstance.gameData.charDEX.ToString();
                break;
            case "INT":
                GameManager.gmInstance.gameData.charINT += 5;
                m_IntelligenceText.text = "INT: " + GameManager.gmInstance.gameData.charINT.ToString();
                break;
            case "WIS":
                GameManager.gmInstance.gameData.charWIS += 5;
                m_WisdomText.text = "WIS: " + GameManager.gmInstance.gameData.charWIS.ToString();
                break;
        }
    }
}
