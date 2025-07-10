using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/Base Data")]
public class Data : ScriptableObject
{
    [Header("Movement State")]
    public float Velocity = 5f;

}
