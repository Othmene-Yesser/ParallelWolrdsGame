using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerManager player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
    }
    private void Start()
    {
        //! Load PlayerData On Start
        if (player.playerData == null)
        {
            player.playerData = new PlayerData();
            SaveManager.SavePlayerPrefs(player.playerData);
        }
        else
        {
            SaveManager.LoadPlayerPrefs(ref player.playerData);
            player.transform.position = player.playerData.Position;
        }
    }
    public void LoadPlayerData()
    {
        //! Load
        if (player.playerData == null)
        {
            player.playerData = new PlayerData();
        }
        SaveManager.LoadPlayerPrefs(ref player.playerData);
        player.transform.position = player.playerData.Position;
    }
    public void SavePlayerData()
    {
        //! Save 
        if (player.playerData == null)
        {
            player.playerData = new PlayerData();
        }
        player.playerData.Position = player.transform.position;
        SaveManager.SavePlayerPrefs(player.playerData);
    }
}
