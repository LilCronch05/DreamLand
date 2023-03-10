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
    private TextMeshProUGUI m_ConstitutionText, m_StrengthText, m_DexterityText, m_IntelligenceText, m_WisdomText, m_NameText;

    private void Start()
    {
        m_ConstitutionText.text = "CON: " + GameManager.gmInstance.gameData.charCON.ToString();
        m_StrengthText.text = "STR: " + GameManager.gmInstance.gameData.charSTR.ToString();
        m_DexterityText.text = "DEX: " + GameManager.gmInstance.gameData.charDEX.ToString();
        m_IntelligenceText.text = "INT: " + GameManager.gmInstance.gameData.charINT.ToString();
        m_WisdomText.text = "WIS: " + GameManager.gmInstance.gameData.charWIS.ToString();

        m_NameText.text = GameManager.gmInstance.gameData.charName;
    }
}
