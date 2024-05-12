using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value <= 0)
            {
                Debug.Log("Play DeathAnimation");
                Invoke(nameof(Death),0.2f);
            }

            if (health != value)
            {
                Debug.Log("HP was :" + health + " / HP is :" + value);
            }
            health = value;
        }
    }

    [SerializeField] private float health;
    private float importance;

    Rigidbody rb;

    private void OnEnable()
    {
        health = 100f;
        importance = Random.Range(1f, 4f);
    }
    private void Death()
    {
        var playerManager = FindObjectOfType<PlayerManager>();
        ExperienceManager.GainExperience(ref playerManager.playerData, importance);
        Destroy(this.gameObject);
    }
}
