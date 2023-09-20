using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Player Data")]
public class PlayerSO : ScriptableObject
{
    [Header("PlayerData")]
    public string playerName;
    public string playerDescription;
    public int level;
    public int experience;
    public int health;
    public int atkValue;
    public int defValue;
    public float criticalValue;
    public int gold;
}
