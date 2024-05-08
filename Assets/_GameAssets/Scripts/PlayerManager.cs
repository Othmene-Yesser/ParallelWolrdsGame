using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Vector3 playerMovement;
    void Update()
    {
        playerMovement.x = Input.GetAxis("Horizontal");
        playerMovement.z = Input.GetAxis("Vertical");
        playerMovement.y = 0f;
        playerMovement.Normalize();
        
        transform.position += playerMovement;
    }
}
