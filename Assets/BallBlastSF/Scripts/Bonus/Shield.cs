using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] SpriteRenderer wallSprite;
    [SerializeField] SpriteRenderer turretSprite;
    [SerializeField] SpriteRenderer towerSprite;

    [SerializeField] private float shieldTimer;
    [SerializeField] private float timerLeft;
    [SerializeField] public static bool ShieldActivated;

    private void Awake()
    {
        ResetShield();
    }

    private void Update()
    {
        if (ShieldActivated == true)
        {
            wallSprite.enabled = true;
            towerSprite.enabled = true;
            turretSprite.enabled = false;

            timerLeft -= Time.deltaTime;

            if (timerLeft <= 0)
            {
                ResetShield();
            }
        }
    }

    public void AddShield()
    {
        ShieldActivated = true;

        timerLeft = shieldTimer;
    }

    private void ResetShield()
    {
        ShieldActivated = false;

        timerLeft = 0;

        wallSprite.enabled = false;
        towerSprite.enabled = false;
        turretSprite.enabled = true;   
    }
}
