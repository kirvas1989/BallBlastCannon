using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin goldPrefab;
    [SerializeField] private int goldDropChance;

    [SerializeField] private Coin fireratePrefab;
    [SerializeField] private int firerateDropChance;

    [SerializeField] private Coin powerPrefab;
    [SerializeField] private int powerDropChance;

    [SerializeField] private Coin weaponPrefab;
    [SerializeField] private int weaponDropChance;

    [SerializeField] private Coin shieldPrefab;
    [SerializeField] private int shieldDropChance;

    [SerializeField] private Coin freezePrefab;
    [SerializeField] private int freezeDropChance;

    private Coin coinPrefab;

    private Vector3 offset;
    private Vector3 addOffset;

    private void Awake()
    {
        offset = new Vector3(0, 0, 0.0001f);

        addOffset = new Vector3(0, 0, 0.0001f);
    }

    public void SpawnCoin()
    {
        int rndGold = Random.Range(0, 100);
        int rndFirerate = Random.Range(0, 100);
        int rndPower = Random.Range(0, 100);
        int rndWeapon = Random.Range(0, 100);
        int rndShield = Random.Range(0, 100);
        int rndFreeze = Random.Range(0, 100);

        if (rndGold < goldDropChance)
        {
            coinPrefab = goldPrefab;
        }
        else if (rndFirerate < firerateDropChance)
        {
            coinPrefab = fireratePrefab;
        }
        else if (rndPower < powerDropChance)
        {
            coinPrefab = powerPrefab;
        }
        else if (rndWeapon < weaponDropChance)
        {
            coinPrefab = weaponPrefab;
        }
        else if (rndShield < shieldDropChance)
        {
            coinPrefab = shieldPrefab;
        }
        else if (rndFreeze < freezeDropChance)
        {
            coinPrefab = freezePrefab;
        }
        else return;

        Coin coin = Instantiate(coinPrefab, transform.position, Quaternion.identity);
        coin.transform.position += offset;
        
        offset += addOffset;          
    }
}
