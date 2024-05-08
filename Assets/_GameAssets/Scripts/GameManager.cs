using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    PlayerManager player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
        player.playerData = playerData;
    }
    private void Update()
    {
        playerData.Position = player.transform.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //! Save 
            SaveManager.SavePlayerPrefs(playerData);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //! Load
            SaveManager.LoadPlayerPrefs(ref playerData);
            player.transform.position = playerData.Position;
        }
    }
}
