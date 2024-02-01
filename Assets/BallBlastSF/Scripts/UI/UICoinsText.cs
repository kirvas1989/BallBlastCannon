using TMPro;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    [SerializeField] private Bag bag;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private string markCoinsText;

    private void FixedUpdate()
    {
        coinsText.text = bag.AmountCoin + " " + markCoinsText;
    }
}
