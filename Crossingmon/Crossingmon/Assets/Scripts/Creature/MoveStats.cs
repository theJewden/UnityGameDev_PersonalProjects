using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create A Move")]

public class MoveStats : ScriptableObject
{
    public string moveName;

    public float moveSpeed;
    public float moveAttack;
    public float moveDefense;

    public enum MoveType
    {
        Fire,
        Grass,
        Water,
        Normal
    }

    public MoveType moveType = MoveType.Grass; 
}
