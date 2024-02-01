using UnityEngine;
using System.Collections.Generic;

public enum CoinType
{
    Gold,
    Firerate,
    Damage,
    Weapon,
    Shield,
    Freeze
}

public class Coin : PickUp
{
    [SerializeField] private CoinType type;

    private Cart cart;
    private StoneSpawner stoneSpawner;
    private Freeze freeze;
    private Shield shield;
    private Power power;
    private Weapon weapon; 
    private Haste firerate;

    private List<Layer> layers = new();
    private Layer[] layerArray;

    private List<Stone> stones = new();
    private Stone[] stoneArray;

    private List<StoneMovement> stoneMovements = new();
    private StoneMovement[] stoneMovementArray;

    public CoinType Type => type;

    private void Awake()
    {
        cart = FindObjectOfType<Cart>();
        stoneSpawner = FindObjectOfType<StoneSpawner>();
        freeze = FindObjectOfType<Freeze>();
        shield = FindObjectOfType<Shield>();
        power = FindObjectOfType<Power>();
        weapon = FindObjectOfType<Weapon>();    
        firerate = FindObjectOfType<Haste>();   
    }

    public void Start()
    {
        stoneArray = FindObjectsOfType<Stone>();
        foreach (Stone stone in stoneArray)
        {
            stones.Add(stone);
        }

        stoneMovementArray = FindObjectsOfType<StoneMovement>();
        foreach (StoneMovement stoneMovement in stoneMovementArray)
        {
            stoneMovements.Add(stoneMovement);
        }

        layerArray = FindObjectsOfType<Layer>();
        foreach (Layer layer in layerArray)
        {
            layers.Add(layer);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Bag bag = collision.GetComponent<Bag>();

        if (bag != null)
        {          
            if (type == CoinType.Gold)
            {
                bag.AddCoin(1);
            }

            if (type == CoinType.Damage)
            {
                if (power != null) power.AddPower();
            }

            if (type == CoinType.Firerate)
            {
                if (firerate != null) firerate.AddHaste();
            }

            if (type == CoinType.Weapon)
            {
                if (weapon != null) weapon.AddWeapon();
            }

            if (type == CoinType.Shield)
            {
                if (cart != null) shield.AddShield();
            }

            if (type == CoinType.Freeze)
            {
                if (stoneSpawner != null)
                {
                    if (stoneMovementArray != null)
                    {
                        for (int i = 0; i < stoneMovementArray.Length; i++)
                        {
                            if (stoneArray != null)
                            {
                                for (int j = 0; j < stoneArray.Length; j++)
                                {
                                    if (layerArray != null)
                                    {
                                        for (int k = 0; k < layerArray.Length; k++)
                                        {
                                            if (freeze != null)
                                            {
                                                freeze.AddFreeze();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}


