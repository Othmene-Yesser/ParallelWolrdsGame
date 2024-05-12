using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerManager player;

    private void Awake()
    {
        SaveManager.CreateNewSave();
        
        player = FindObjectOfType<PlayerManager>();
        
    }

    private void Start()
    {
        player.playerData = new PlayerData();
        SaveManager.LoadPlayerPrefs(ref player.playerData);
    }

    public void LoadPlayerData()
    {
        //! Load
        if (player.playerData == null)
        {
            Debug.LogError("There was no save data");
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
    public void BeatBothBosses()
    {
        SaveManager.BeatBizarreBoss();
        SaveManager.BeatAgilityBoss();
    }
}
