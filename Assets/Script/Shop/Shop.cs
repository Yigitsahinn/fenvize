using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private Button upgradeButton;
    public int upgradeCost = 100;
    public int upgradeAmount = 50;

    PlayerStats stats;
    void Start()
    {
        stats = Player.instance.playerStats;
        shopPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            shopPanel.SetActive(!shopPanel.activeSelf);
        }
    }

    public void BuyDamageUpgrade()
    {
        int maxLevel = 3;
        int currentLevel = 0;

        if (currentLevel >= maxLevel)
        {
            Debug.Log("Bu upgrade zaten maksimum seviyede.");
            return;
        }
        if (stats.coins >= upgradeCost && currentLevel <= maxLevel)
        {
            stats.coins -= upgradeCost;
            stats.damage += upgradeAmount;
            currentLevel++;
            UpdateUI();
            Debug.Log($"Damage upgrade alýndý! Yeni hasar: {stats.damage}");
        }
        else
        {
            Debug.Log("Yeterli altýn yok.");
        }
        
    }
    private void UpdateUI()
    {
        upgradeAmount = upgradeAmount + 50;
        upgradeCost = upgradeCost + 100;
        upgradeButton.GetComponentInChildren<Text>().text = $"Damage Upgrade: {upgradeAmount} Cost: ({upgradeCost} coins)";
    }
}
