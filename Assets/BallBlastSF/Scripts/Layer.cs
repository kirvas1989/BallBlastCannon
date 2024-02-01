using UnityEngine;

public class Layer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer originalSpriteRenderer;
    [SerializeField] private SpriteRenderer optionalSpriteRenderer;
    [SerializeField] private Canvas canvas;
    [SerializeField] private int startingLayer;
    [SerializeField] private int currentLayer;

    public void AddLayerOrder()
    {
        currentLayer++;

        originalSpriteRenderer.sortingOrder++;

        optionalSpriteRenderer.sortingOrder++;

        canvas.sortingOrder++;
    }

    private void Update()
    {
        if (Freeze.FreezeActivated == false)
        {
            originalSpriteRenderer.sortingOrder = currentLayer;
            optionalSpriteRenderer.sortingOrder = currentLayer - 1;
        }
               
        if (Freeze.FreezeActivated == true)
        { 
            optionalSpriteRenderer.sortingOrder = currentLayer;
            originalSpriteRenderer.sortingOrder = currentLayer - 1;
        }
    }
}
