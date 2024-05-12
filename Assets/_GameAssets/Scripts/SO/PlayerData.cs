using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerData", menuName = "Data/NewPlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("PlayerStats")]
    public int Level = 1;
    public float ExperiencePoints = 0;
    public float MaxHealth = 100f;
    public float Health;
    public float MaxStamina = 50f;
    public float Stamina;
    public float Speed = 3f;
    public float Damage = 12.5f;
    [Header("Postion")]
    public int Dimension = 1;
    public Vector3 Position;
}
