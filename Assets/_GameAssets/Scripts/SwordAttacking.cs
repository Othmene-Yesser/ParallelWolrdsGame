using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttacking : MonoBehaviour
{
    PlayerManager playerManager;
    private void OnEnable()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && playerManager.animatorManager.animator.GetBool("IsAttacking"))
        {
            var enemy = other.GetComponent<Enemy>();
            playerManager.animatorManager.animator.SetBool("IsAttacking", false);
            enemy.Health -= playerManager.playerData.Damage;
        }
    }
}
