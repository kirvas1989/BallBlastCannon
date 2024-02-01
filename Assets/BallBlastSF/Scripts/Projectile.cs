using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    private AudioSource stoneHitSound;
    private int damage;

    private void Awake()
    {
        GameObject projectileSound = GameObject.FindGameObjectWithTag("ProjectileSound");
        stoneHitSound = projectileSound.GetComponent<AudioSource>();
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.GetComponent<Coin>(); 
        
        if (coin != null ) 
        { 
            return;  
        }
        else
        {
            Destructible destructible = collision.transform.root.GetComponent<Destructible>();

            if (destructible != null)
            {
                destructible.ApplyDamage(damage);
                
                stoneHitSound.Play();
            }

            Destroy(gameObject);
        } 
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
