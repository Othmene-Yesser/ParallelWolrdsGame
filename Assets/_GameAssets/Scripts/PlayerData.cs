using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerData", menuName = "Data/NewPlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("PlayerStats")]
    public float MaxHealth;
    public float Health;
    public float MaxStamina;
    public float Stamina;
    public float Speed;
    [Header("Postion")]
    public int Dimension;
    public Vector3 Position;
}
