using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterProfile
{
    public string characterName;
    public int characterClassIndex;
    public int characterStatPoints;
    public int characterLevel;
    public int characterExperience;

    // Character Stats
    public int characterConstitution;
    public int characterStrength;
    public int characterDexterity;
    public int characterIntelligence;
    public int characterWisdom;

    public CharacterProfile()
    {
        characterName = "New Character";
        characterClassIndex = 0;
        characterStatPoints = 50;
        characterLevel = 1;
        characterExperience = 0;

        // Get Character Stats from StatManager
        characterConstitution = 0;
        characterStrength = 0;
        characterDexterity = 0;
        characterIntelligence = 0;
        characterWisdom = 0;
    }
    public CharacterProfile(string changeName, int changeClass, int statPoints, int increaseLevel, int addExperience, int constitution, int strength, int dexterity, int intelligence, int wisdom)
    {
        characterName = changeName;
        characterClassIndex = changeClass;
        characterStatPoints = statPoints;
        characterLevel = increaseLevel;
        characterExperience = addExperience;

        //Character Stats
        characterConstitution = constitution;
        characterStrength = strength;
        characterDexterity = dexterity;
        characterIntelligence = intelligence;
        characterWisdom = wisdom;
    }
    public string GetCharacterName()
    {
        return characterName;
    }
    public void SetCharacterName(string changeName)
    {
        characterName = changeName;
    }
    public int GetCharacterClass()
    {
        return characterClassIndex;
    }
    public void SetCharacterClass(int changeClass)
    {
        characterClassIndex = changeClass;
    }
    public int GetCharacterStatPoints()
    {
        return characterStatPoints;
    }
    public void SetCharacterStatPoints(int statPoints)
    {
        characterStatPoints = statPoints;
    }
    public int GetCharacterLevel()
    {
        return characterLevel;
    }
    public void SetCharacterLevel(int increaseLevel)
    {
        characterLevel = increaseLevel;
    }
    public int GetCharacterExperience()
    {
        return characterExperience;
    }
    public void SetCharacterExperience(int addExperience)
    {
        characterExperience = addExperience;
    }
    public int GetCharacterConstitution()
    {
        return characterConstitution;
    }
    public void SetCharacterConstitution(int constitution)
    {
        characterConstitution = constitution;
    }
    public int GetCharacterStrength()
    {
        return characterStrength;
    }
    public void SetCharacterStrength(int strengthValue)
    {
        characterStrength = strengthValue;
    }
    public int GetCharacterDexterity()
    {
        return characterDexterity;
    }
    public void SetCharacterDexterity(int dexterityValue)
    {
        characterDexterity = dexterityValue;
    }
    public int GetCharacterIntelligence()
    {
        return characterIntelligence;
    }
    public void SetCharacterIntelligence(int intelligenceValue)
    {
        characterIntelligence = intelligenceValue;
    }
    public int GetCharacterWisdom()
    {
        return characterWisdom;
    }
    public void SetCharacterWisdom(int wisdomValue)
    {
        characterWisdom = wisdomValue;
    }
}
