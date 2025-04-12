using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    PlayerStats stats;

    private void Start()
    {
        stats = Player.instance.playerStats;
    }

   


    //private Dictionary<UpgradeData, int> upgradeLevels = new();

    //public void TryBuyUpgrade(UpgradeData upgrade)
    //{
    //    int currentLevel = upgradeLevels.ContainsKey(upgrade) ? upgradeLevels[upgrade] : 0;

    //    if (currentLevel >= upgrade.maxLevel)
    //    {
    //        Debug.Log("Bu upgrade zaten maksimum seviyede.");
    //        return;
    //    }

    //    UpgradeLevel nextLevel = upgrade.levels[currentLevel];

    //    if (stats.coins >= nextLevel.cost)
    //    {
    //        stats.coins -= nextLevel.cost;
    //        upgradeLevels[upgrade] = currentLevel + 1;
    //        ApplyUpgrade(upgrade, nextLevel);
    //        Debug.Log($"{upgrade.upgradeName} seviye {currentLevel + 1} alýndý!");
    //    }
    //    else
    //    {
    //        Debug.Log("Yeterli altýn yok.");
    //    }
    //}

    //private void ApplyUpgrade(UpgradeData upgrade, UpgradeLevel levelData)
    //{
    //    // upgrade.type'e göre oyuncuya etkisini uygula
    //    stats.damage += levelData.value;
    //    stats.health += levelData.value;
    //    stats.speed += levelData.value;
    //    Debug.Log($"{upgrade.upgradeName} etkisi: +{levelData.value}");
    //}
}
    
