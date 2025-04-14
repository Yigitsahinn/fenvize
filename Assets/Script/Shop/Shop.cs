using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI healthText;
    private PlayerStats stats;
    private PlayerAttackScript playerAttackScript;
    public Dictionary<PlayerStat, UpgradeData> upgradeDatas = new();


    private void Awake()
    {
        playerAttackScript = Player.instance.GetComponent<PlayerAttackScript>();
        instance = this;
        GetUpgradeDatas();
    }
    void Start()
    {
        stats = Player.instance.playerStats;
        shopPanel.SetActive(false);
    }

    private void GetUpgradeDatas()
    {
        UpgradeData[] datas = Resources.FindObjectsOfTypeAll<UpgradeData>();
        foreach (UpgradeData data in datas)
        {
            if (!upgradeDatas.ContainsKey(data.type))
            {
                upgradeDatas.Add(data.type, data);
            }
            else
            {
                Debug.LogError("Duplicate UpgradeData found for type: " + data.type);
            }
            data.currentLevel = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
            playerAttackScript.canAttack = !shopPanel.activeSelf;
            playerAttackScript.canMove = !shopPanel.activeSelf;
        }
        coinsText.text = stats.coins.ToString();
        healthText.text = stats.health.ToString();
    }

    public void BuyUpgrade(PlayerStat targetStat)
    {
        UpgradeData upgradeData = upgradeDatas[targetStat];

        int targetLevel = upgradeData.currentLevel;

        if (targetLevel >= upgradeData.maxLevel)
        {
            return;
        }

        if(stats.coins < upgradeData.levels[targetLevel].cost)
        {
            return;
        }

        stats.AddToStat(targetStat,upgradeData.levels[targetLevel].value);
        stats.coins -= upgradeData.levels[targetLevel].cost;
        upgradeData.currentLevel++;

    }
}
