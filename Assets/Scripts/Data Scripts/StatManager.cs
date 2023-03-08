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

    public int m_Constitution, m_Strength, m_Dexterity, m_Intelligence, m_Wisdom;
    [SerializeField]
    private TextMeshProUGUI m_ConstitutionText, m_StrengthText, m_DexterityText, m_IntelligenceText, m_WisdomText, m_NameText;

    private void Start()
    {
        m_Constitution = GameManager.gmInstance.gameData.charCON;
        m_Strength = GameManager.gmInstance.gameData.charSTR;
        m_Dexterity = GameManager.gmInstance.gameData.charDEX;
        m_Intelligence = GameManager.gmInstance.gameData.charINT;
        m_Wisdom = GameManager.gmInstance.gameData.charWIS;

        m_ConstitutionText.text = "CON: " + m_Constitution.ToString();
        m_StrengthText.text = "STR: " + m_Strength.ToString();
        m_DexterityText.text = "DEX: " + m_Dexterity.ToString();
        m_IntelligenceText.text = "INT: " + m_Intelligence.ToString();
        m_WisdomText.text = "WIS: " + m_Wisdom.ToString();

        m_NameText.text = GameManager.gmInstance.gameData.charName;
    }
}
