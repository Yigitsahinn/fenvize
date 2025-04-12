using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private PlayerStat stat;
    [SerializeField] private TMP_Text buttonText;
    private Button button;
    private Shop shop => Shop.instance;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            shop.BuyUpgrade(stat);
        });

        buttonText.SetText(shop.upgradeDatas[stat].upgradeName);

    }

}
