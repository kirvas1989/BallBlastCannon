using UnityEngine;

public class Haste : MonoBehaviour
{
    [SerializeField] public float LevelHaste;
    [SerializeField] private float currentHaste;
    [SerializeField] private float bonusAmount;
    [SerializeField] private bool firerateActivated;
    [SerializeField] private float firerateTimer;
    [SerializeField] private float timerLeft;

    public static float BonusFirerate;

    public float BonusAmount => bonusAmount;

    private void Awake()
    {
        LoadAmountHaste();
        
        ResetHaste();
    }

    private void Update()
    {      
        if (firerateActivated == true)
        {
            timerLeft -= Time.deltaTime;

            BonusFirerate = currentHaste;

            if (BonusFirerate < 0) BonusFirerate = 0;
            
            if (timerLeft <= 0)
            {
                ResetHaste();
            }
        }
    }

    private void ResetHaste()
    {
        firerateActivated = false;

        timerLeft = 0;

        currentHaste = LevelHaste;

        BonusFirerate = currentHaste;
    }

    public void AddHaste()
    {
        firerateActivated = true;

        timerLeft = firerateTimer;

        currentHaste -= bonusAmount; 
    }

    public void SaveAmountHaste()
    {
        PlayerPrefs.SetFloat("Haste:AmountHaste", LevelHaste);
    }

    private void LoadAmountHaste()
    {
        LevelHaste = PlayerPrefs.GetFloat("Haste:AmountHaste", 0.2f);
    }
}
