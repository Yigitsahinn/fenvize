using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int coins;
    [SerializeField] private List<StatStruct> playerStats;

    private Dictionary<PlayerStat, float> statsDict = new();

    public float damage => statsDict[PlayerStat.Damage];
    public float health => statsDict[PlayerStat.Health];
    public float speed => statsDict[PlayerStat.Speed];

    private void Awake()
    {
        foreach(StatStruct stat in playerStats)
        {
            statsDict.Add(stat.type, stat.startValue);
        }
    }

    private void Start()
    {
        string str = "";
        foreach (var pair in statsDict)
        {
            str += pair.Key + ": " + pair.Value + "\n";
        }
        print(str);
    }

    public void AddToStat(PlayerStat targetStat, float value)
    {
        statsDict[targetStat] += value;

        string str = "";
        foreach (var pair in statsDict)
        {
            str += pair.Key + ": " + pair.Value + "\n";
        }
        print(str);
    }

    [System.Serializable]
    private struct StatStruct
    {
        public PlayerStat type;
        public float startValue;
    }
}
