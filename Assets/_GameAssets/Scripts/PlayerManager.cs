using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] 
    public PlayerData playerData;
    Vector3 playerMovement;
    void Update()
    {
        playerMovement.x = Input.GetAxis("Horizontal");
        playerMovement.z = Input.GetAxis("Vertical");
        playerMovement.y = 0f;
        playerMovement.Normalize();

        transform.Translate(playerMovement * Time.deltaTime * playerData.Speed);
    }
}
