using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] public int LevelWeapon;
    [SerializeField] private int currentWeapon;   
    [SerializeField] private int bonusAmount; 
    [SerializeField] private bool weaponActivated;
    [SerializeField] private float weaponTimer;
    [SerializeField] private float timerLeft;

    public static int BonusProjectileAmount;

    private void Awake()
    {
        LoadAmountWeapon();
        
        ResetWeapon();
    }

    private void Update()
    {
        if (weaponActivated == true)
        {
            timerLeft -= Time.deltaTime;

            BonusProjectileAmount = currentWeapon;

            if (timerLeft <= 0)
            {
                ResetWeapon();
            }
        }
    }

    private void ResetWeapon()
    {
        weaponActivated = false;

        timerLeft = 0;

        currentWeapon = LevelWeapon;

        BonusProjectileAmount = currentWeapon;
    }

    public void AddWeapon()
    {
        weaponActivated = true;

        timerLeft = weaponTimer;

        currentWeapon += bonusAmount;
    }

    public void SaveAmountWeapon()
    {
        PlayerPrefs.SetInt("Weapon:AmountWeapon", LevelWeapon);
    }

    private void LoadAmountWeapon()
    {
        LevelWeapon = PlayerPrefs.GetInt("Weapon:AmountWeapon", 1);
    }
}
