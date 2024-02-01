using UnityEngine;
using UnityEngine.Events;

public class Bag : MonoBehaviour
{
    [SerializeField] public int AmountCoin;

    public UnityEvent ChangeAmountCoin;

    private void Awake()
    {
        LoadAmountCoin();
    }

    public void AddCoin(int amount)
    {
        AmountCoin += amount;

        ChangeAmountCoin.Invoke();

        SaveAmountCoin();
    }

    public bool DrawCoin(int amount)
    {
        if (AmountCoin - amount < 0) return false;

        AmountCoin -= amount;

        ChangeAmountCoin.Invoke();

        return true;
    }

    public int GetAmountCoin()
    {
        return AmountCoin;
    }

    public void SaveAmountCoin()
    {
        PlayerPrefs.SetInt("Bag:AmountCoins", AmountCoin);
    }

    private void LoadAmountCoin()
    {
        AmountCoin = PlayerPrefs.GetInt("Bag:AmountCoins", 0);
    }
}
