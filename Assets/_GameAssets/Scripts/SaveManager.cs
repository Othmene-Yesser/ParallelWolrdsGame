using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    static string PlayerPositionX = "PlayerPositionX";
    static string PlayerPositionY = "PlayerPositionY";
    static string PlayerPositionZ = "PlayerPositionZ";
    static string PlayerHealth = "PlayerHealth";
    static string PlayerMaxHealth = "PlayerMaxHealth";
    static string PlayerStamina = "PlayerStamina";
    static string PlayerMaxStamina = "PlayerMaxStamina";
    static string PlayerSpeed = "PlayerSpeed";
    static string PlayerDimension = "PlayerDimension";

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
