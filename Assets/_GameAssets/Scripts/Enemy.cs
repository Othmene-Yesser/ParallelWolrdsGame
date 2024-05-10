using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float health;
    private void OnEnable()
    {
        health = 100f;
    }
    private void Death()
    {
        Destroy(this.gameObject);
    }
}
