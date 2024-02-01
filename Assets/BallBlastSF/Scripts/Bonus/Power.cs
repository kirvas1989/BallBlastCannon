using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField] public int LevelPower;
    [SerializeField] private int currentDamage;        
    [SerializeField] private int bonusAmount;
    [SerializeField] private bool powerActivated;
    [SerializeField] private float powerTimer;
    [SerializeField] private float timerLeft;
  
    public static int BonusDamage;

    private void Awake()
    {
        LoadAmountPower();
        
        ResetPower();  
    }

    private void Update()
    {
        if (powerActivated == true)
        {
            BonusDamage = currentDamage;

            timerLeft -= Time.deltaTime;

            if (timerLeft <= 0)
            {
                ResetPower();   
            }
        }
    }

    private void ResetPower()
    {
        powerActivated = false;

        timerLeft = 0;

        currentDamage = LevelPower;

        BonusDamage = currentDamage;
    }

    public void AddPower()
    {
        powerActivated = true;

        timerLeft = powerTimer;

        currentDamage += bonusAmount;
    }

    public void SaveAmountPower()
    {
        PlayerPrefs.SetInt("Power:AmountPower", LevelPower);
    }

    private void LoadAmountPower()
    {
        LevelPower = PlayerPrefs.GetInt("Power:AmountPower", 1);
    }
}
