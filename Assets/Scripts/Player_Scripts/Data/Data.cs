using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/Base Data")]
public class Data : ScriptableObject
{
    [Header("Movement State")]
    public float walkingVelocity = 3f;
    public float sprintingVelocity = 6f;

}
