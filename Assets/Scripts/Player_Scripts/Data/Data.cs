using System.ComponentModel.Design;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/Base Data")]
public class Data : ScriptableObject
{
    [Header("Movement State")]
    public float walkingVelocity = 3f;
    public float sprintingVelocity = 6f;

    [Header("Jump State")]
    public float jumpVelocity = 2f;

    [Header("Check Variables")]
    public float GroundCheckRadius = 0.3f;
    public LayerMask WhatIsGround;

}
