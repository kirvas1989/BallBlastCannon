using TMPro;
using UnityEngine;

public class UIShopText : MonoBehaviour
{
    [SerializeField] private Shop shop;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI weaponText;
    [SerializeField] private TextMeshProUGUI hasteText;
    [SerializeField] private TextMeshProUGUI liveText;

    [SerializeField] private string markShopText;

    private void Start()
    {
        powerText.text = shop.PowerPrice + " " + markShopText;

        weaponText.text = shop.WeaponPrice + " " + markShopText;

        hasteText.text = shop.HastePrice + " " + markShopText;  

        liveText.text = shop.LivePrice + " " + markShopText;
    }
}
