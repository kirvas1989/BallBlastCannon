using UnityEngine;

public class PickUp : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Cart cart = collision.GetComponent<Cart>();

        if (cart!= null)
        {
            Destroy(gameObject);
        }
    }
}
