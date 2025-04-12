using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Scriptable Objects/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    
    public string upgradeName;
    public string description;
    public UpgradeType type;
    public int cost;
    public int maxLevel = 3;
    public UpgradeLevel[] levels;
}
public enum UpgradeType
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
    public int level;
    public float value; 
    public int cost;
}

