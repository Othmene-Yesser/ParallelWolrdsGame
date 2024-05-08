using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Vector3 playerPosition;
    [SerializeField] float health;
    [SerializeField] float stamina;
    Transform player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().transform;
    }
    private void Update()
    {
        playerPosition = player.position;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //! Save 
            SaveManager.SavePlayerPrefs(playerPosition, health, stamina);
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //! Load
            SaveManager.LoadPlayerPrefs(out playerPosition, out health,out stamina);
            player.position = playerPosition;
        }
    }
}
