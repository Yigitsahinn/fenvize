using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private PlayerStat stat;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text descriptionText;
    private Button button;
    private Shop shop => Shop.instance;
    private PlayerStats stats => Player.instance.playerStats;

    private void Start()
    {
        UpdateCostText();
    }
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            shop.BuyUpgrade(stat);
            UpdateCostText();
        });

        nameText.SetText(shop.upgradeDatas[stat].upgradeName);
        descriptionText.SetText(shop.upgradeDatas[stat].description);
    }
    private void UpdateCostText()
    {
        int curLevel = shop.upgradeDatas[stat].currentLevel;
        int cost = shop.upgradeDatas[stat].levels[curLevel].cost;
        costText.SetText(" " + cost + " " + "Gold");

    }
    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        int curLevel = shop.upgradeDatas[stat].currentLevel;
        if (stats.coins < shop.upgradeDatas[stat].levels[shop.upgradeDatas[stat].currentLevel].cost)
        {
            costText.color = Color.red;
            button.interactable = false;
        }
        else
        {
            costText.color = Color.white;
            button.interactable = true;
        }
        if (curLevel == 3)
        {
            costText.SetText("Max Level");
            costText.color = Color.white;
            button.interactable = false;
        }
    }
}
