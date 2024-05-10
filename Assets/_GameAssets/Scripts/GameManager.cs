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

    private void Update()
    {
        player.playerData.Position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //! Save 
            SaveManager.SavePlayerPrefs(player.playerData);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //! Load
            SaveManager.LoadPlayerPrefs(ref player.playerData);
            player.transform.position = player.playerData.Position;
        }
    }
}
