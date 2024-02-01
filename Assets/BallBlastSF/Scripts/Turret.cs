using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float projectileInterval;
    [SerializeField] private int damage;
    [SerializeField] private int projectileAmount;
    [SerializeField] private float firerate;

    private float timer;

    public int Damage => damage;
    public int ProjectileAmount => projectileAmount;
    public float Firerate => firerate;

    void Update()
    {
        timer += Time.deltaTime;

        damage = Power.BonusDamage;

        firerate = Haste.BonusFirerate;

        projectileAmount = Weapon.BonusProjectileAmount;
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }
    }

    public void Fire()
    {     
        if (timer >= firerate)
        {
            SpawnProjectile();

            timer = 0;
        }
    }
}

