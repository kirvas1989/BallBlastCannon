using UnityEngine;

public class CoinSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioGold;
    [SerializeField] private AudioSource audioPower;
    [SerializeField] private AudioSource audioHaste;
    [SerializeField] private AudioSource audioWeapon;
    [SerializeField] private AudioSource audioShield;
    [SerializeField] private AudioSource audioFreeze;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>(); 
        if (coin != null)
        {
            if (coin.Type == CoinType.Gold) audioGold.Play();

            if (coin.Type == CoinType.Damage) audioPower.Play();    

            if (coin.Type == CoinType.Firerate) audioHaste.Play();

            if (coin.Type == CoinType.Weapon) audioWeapon.Play();

            if (coin.Type == CoinType.Shield) audioShield.Play();

            if (coin.Type == CoinType.Freeze) audioFreeze.Play();
        }
    }
}
