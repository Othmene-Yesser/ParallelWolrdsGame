using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    static readonly string PlayerPositionX = "PlayerPositionX";
    static readonly string PlayerPositionY = "PlayerPositionY";
    static readonly string PlayerPositionZ = "PlayerPositionZ";
    static readonly string PlayerHealth = "PlayerHealth";
    static readonly string PlayerMaxHealth = "PlayerMaxHealth";
    static readonly string PlayerStamina = "PlayerStamina";
    static readonly string PlayerMaxStamina = "PlayerMaxStamina";
    static readonly string PlayerSpeed = "PlayerSpeed";
    static readonly string PlayerDimension = "PlayerDimension";

    public static void SavePlayerPrefs(PlayerData playerData)
    {
        PlayerPrefs.SetFloat(PlayerPositionX, playerData.Position.x);
        PlayerPrefs.SetFloat(PlayerPositionY, playerData.Position.y);
        PlayerPrefs.SetFloat(PlayerPositionZ, playerData.Position.z);
        PlayerPrefs.SetFloat(PlayerHealth, playerData.Health);
        PlayerPrefs.SetFloat(PlayerMaxHealth, playerData.MaxHealth);
        PlayerPrefs.SetFloat(PlayerStamina, playerData.Stamina);
        PlayerPrefs.SetFloat(PlayerMaxStamina, playerData.MaxStamina);
        PlayerPrefs.SetFloat(PlayerSpeed, playerData.Speed);
        PlayerPrefs.SetInt(PlayerDimension, playerData.Dimension);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }
    public static void LoadPlayerPrefs(ref PlayerData playerData)
    {
        playerData.Position.x = PlayerPrefs.GetFloat(PlayerPositionX);
        playerData.Position.y = PlayerPrefs.GetFloat(PlayerPositionY);
        playerData.Position.z = PlayerPrefs.GetFloat(PlayerPositionZ);
        playerData.MaxHealth = PlayerPrefs.GetFloat(PlayerMaxHealth);
        playerData.MaxStamina = PlayerPrefs.GetFloat(PlayerMaxStamina);
        playerData.Health = PlayerPrefs.GetFloat(PlayerHealth);
        playerData.Stamina = PlayerPrefs.GetFloat(PlayerStamina);
        playerData.Speed = PlayerPrefs.GetFloat(PlayerSpeed);
        playerData.Dimension = PlayerPrefs.GetInt(PlayerDimension);
        Debug.Log("Loaded");
    }
}

public static class ExperienceManager
{
    public static void GainExperience(ref PlayerData playerData, float importance)
    {
        Debug.Log("Gained "+ playerData.Level * importance * 10 +" EXP");
        //playerData.ExperiencePoints += playerData.Level * importance * 10;
        playerData.ExperiencePoints += RequiredEXPForNextLevel(playerData.Level + 1);
        //! Check if we passed the exp amount to level up
        if (playerData.ExperiencePoints >= RequiredEXPForNextLevel(playerData.Level + 1))
        {
            playerData.ExperiencePoints -= RequiredEXPForNextLevel(playerData.Level + 1);
            LevelUp(ref playerData);
        }
    }
    public static void LevelUp(ref PlayerData playerData)
    {
        playerData.Level++;
        playerData.MaxHealth+= playerData.Level * 0.75f;
        playerData.MaxStamina += playerData.Level * 0.75f;
        playerData.Damage += playerData.Level * 0.5f;
        Debug.Log("LevelUp");
    }
    private static float RequiredEXPForNextLevel(int level)
    {
        return 500 * (level * level) - (500 * level);
    }
}