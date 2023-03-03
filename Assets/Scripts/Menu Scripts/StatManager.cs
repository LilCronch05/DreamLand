using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StatManager : MonoBehaviour
{
    //This is the script that will be used to manage the stats of the character. 
    //  It will be used to add and subtract points from the stats of the character.
    //  It will also be used to save the stats of the character to a file.
    
    //the character will only have 50 points to spend on stats

    //These buttons will be used to add and subtract points from the stats
    public Button addStrength, addDexterity, addConstitution, addIntelligence, addWisdom;
    public Button subtractStrength, subtractDexterity, subtractConstitution, subtractIntelligence, subtractWisdom;

    //These are the text fields that will display the stats
    public TextMeshProUGUI strength, dexterity, constitution, intelligence, wisdom;

    //This is the text field that will display the number of points left to spend
    public TextMeshProUGUI statPoints;

    //These are the variables that will hold the values of the stats
    public int strengthValue, dexterityValue, constitutionValue, intelligenceValue, wisdomValue;

    void Start()
    {
        //This will set the values of the stats to 0
        strengthValue = 0;
        dexterityValue = 0;
        constitutionValue = 0;
        intelligenceValue = 0;
        wisdomValue = 0;

        //This will set the text fields to display the values of the stats
        strength.text = "STR: " + strengthValue.ToString();
        dexterity.text = "DEX: " + dexterityValue.ToString();
        constitution.text = "CON: " + constitutionValue.ToString();
        intelligence.text = "INT: " + intelligenceValue.ToString();
        wisdom.text = "WIS: " + wisdomValue.ToString();

        //This will set the text field to display the number of points left to spend
        statPoints.text = "50";
    }

    //This function will be used to add points to the strength stat
    public void AddStrength()
    {
        //This will check to see if there are any points left to spend
        if (int.Parse(statPoints.text) > 0)
        {
            //This will add a point to the strength stat
            strengthValue++;

            //This will subtract a point from the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) - 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void SubtractStrength()
    {
        //This will check to see if there are any points left to spend
        if (strengthValue > 0)
        {
            //This will subtract a point from the strength stat
            strengthValue--;

            //This will add a point to the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) + 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void AddDexterity()
    {
        //This will check to see if there are any points left to spend
        if (int.Parse(statPoints.text) > 0)
        {
            //This will add a point to the dexterity stat
            dexterityValue++;

            //This will subtract a point from the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) - 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void SubtractDexterity()
    {
        //This will check to see if there are any points left to spend
        if (dexterityValue > 0)
        {
            //This will subtract a point from the dexterity stat
            dexterityValue--;

            //This will add a point to the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) + 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void AddConstitution()
    {
        //This will check to see if there are any points left to spend
        if (int.Parse(statPoints.text) > 0)
        {
            //This will add a point to the constitution stat
            constitutionValue++;

            //This will subtract a point from the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) - 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void SubtractConstitution()
    {
        //This will check to see if there are any points left to spend
        if (constitutionValue > 0)
        {
            //This will subtract a point from the constitution stat
            constitutionValue--;

            //This will add a point to the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) + 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void AddIntelligence()
    {
        //This will check to see if there are any points left to spend
        if (int.Parse(statPoints.text) > 0)
        {
            //This will add a point to the intelligence stat
            intelligenceValue++;

            //This will subtract a point from the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) - 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void SubtractIntelligence()
    {
        //This will check to see if there are any points left to spend
        if (intelligenceValue > 0)
        {
            //This will subtract a point from the intelligence stat
            intelligenceValue--;

            //This will add a point to the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) + 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void AddWisdom()
    {
        //This will check to see if there are any points left to spend
        if (int.Parse(statPoints.text) > 0)
        {
            //This will add a point to the wisdom stat
            wisdomValue++;

            //This will subtract a point from the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) - 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
    public void SubtractWisdom()
    {
        //This will check to see if there are any points left to spend
        if (wisdomValue > 0)
        {
            //This will subtract a point from the wisdom stat
            wisdomValue--;

            //This will add a point to the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text) + 1).ToString();

            //This will set the text fields to display the values of the stats
            strength.text = "STR: " + strengthValue.ToString();
            dexterity.text = "DEX: " + dexterityValue.ToString();
            constitution.text = "CON: " + constitutionValue.ToString();
            intelligence.text = "INT: " + intelligenceValue.ToString();
            wisdom.text = "WIS: " + wisdomValue.ToString();

            //This will set the text field to display the number of points left to spend
            statPoints.text = (int.Parse(statPoints.text)).ToString();
        }
    }
}
