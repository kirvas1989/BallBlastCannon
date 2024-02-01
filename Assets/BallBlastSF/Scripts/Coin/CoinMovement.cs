using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    private Vector3 velocity;
    
    private float gravity;
    private float bounceFactor;
    private int bounce;
    
    private void Awake()
    {
        int rnd = Random.Range(4, 7);

        bounce = rnd;
        
        bounceFactor = 0.7f;

        gravity = 9.8f;
    }

    private void Update()
    {
        if (bounce == 0) return;

        Move();
    }

    private void Move()
    {
        velocity.y -= gravity * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                velocity.y = -velocity.y * bounceFactor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                bounce--;              
            }
        }
    }
}
