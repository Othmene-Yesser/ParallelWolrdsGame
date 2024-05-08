using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    static string PlayerPositionX = "PlayerPositionX";
    static string PlayerPositionY = "PlayerPositionY";
    static string PlayerPositionZ = "PlayerPositionZ";
    static string PlayerHealth = "PlayerHealth";
    static string PlayerStamina = "PlayerStamina";
    static int CurrentDimension = 0;

    public static void SavePlayerPrefs(Vector3 playerPosition, float playerHealth, float playerStamina)
    {
        PlayerPrefs.SetFloat(PlayerPositionX, playerPosition.x);
        PlayerPrefs.SetFloat(PlayerPositionY, playerPosition.y);
        PlayerPrefs.SetFloat(PlayerPositionZ, playerPosition.z);
        PlayerPrefs.SetFloat(PlayerHealth, playerHealth);
        PlayerPrefs.SetFloat(PlayerStamina, playerStamina);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }
    public static void LoadPlayerPrefs(out Vector3 playerPosition, out float playerHealth, out float playerStamina)
    {
        playerPosition.x = PlayerPrefs.GetFloat(PlayerPositionX);
        playerPosition.y = PlayerPrefs.GetFloat(PlayerPositionY);
        playerPosition.z = PlayerPrefs.GetFloat(PlayerPositionZ);
        playerHealth = PlayerPrefs.GetFloat(PlayerHealth);
        playerStamina = PlayerPrefs.GetFloat(PlayerStamina);
        Debug.Log("Loaded");
    }
}
