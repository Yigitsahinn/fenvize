using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;
    public PlayerStat type;
    public int maxLevel = 3;
    public int currentLevel = 0;
    public UpgradeLevel[] levels;
}
[System.Serializable]
public enum PlayerStat
{
    Damage,
    Health,
    Speed,
    CriticalChance,
    CriticalDamage,
}
[System.Serializable]
public class UpgradeLevel
{
    public float value;
    public int cost;
}

