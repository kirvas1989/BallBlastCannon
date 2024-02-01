using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Power power;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Haste haste;
    [SerializeField] private Live live;
    [SerializeField] private Bag bag;

    [Header("Prices")]
    [SerializeField] private int powerPrice;
    [SerializeField] private int weaponPrice;
    [SerializeField] private int hastePrice;
    [SerializeField] private int livePrice;

    [SerializeField] private AudioSource sellAudio;

    public int PowerPrice => powerPrice;
    public int WeaponPrice => weaponPrice;
    public int HastePrice => hastePrice;
    public int LivePrice => livePrice;

    public void BuyPower()
    {
        if (bag.AmountCoin >= powerPrice)
        {          
            bag.AmountCoin -= powerPrice;
            bag.SaveAmountCoin();

            power.LevelPower++;
            power.SaveAmountPower();

            sellAudio.Play();
        }
    }

    public void BuyWeapon()
    {
        if (bag.AmountCoin >= weaponPrice)
        {          
            bag.AmountCoin -= weaponPrice;
            bag.SaveAmountCoin();

            weapon.LevelWeapon++;   
            weapon.SaveAmountWeapon();

            sellAudio.Play();
        }
    }

    public void BuyHaste()
    {
        if (bag.AmountCoin >= hastePrice)
        {          
            bag.AmountCoin -= hastePrice;
            bag.SaveAmountCoin();

            haste.LevelHaste = haste.LevelHaste - haste.BonusAmount;
            haste.SaveAmountHaste();

            sellAudio.Play();
        }
    }

    public void BuyLive()
    {
        if ((bag.AmountCoin >= livePrice) && (live.CurrentLive++ > 0))
        {          
            bag.AmountCoin -= livePrice;
            bag.SaveAmountCoin();

            live.CurrentLive++;
            live.SaveAmountLive();

            sellAudio.Play();
        }
    }
}
