using UnityEngine;

[System.Serializable]
public class LevelPallete
{
    public Color StoneColor;
}

public class StoneColor : MonoBehaviour
{
    [SerializeField] private LevelPallete[] pallete;

    [SerializeField] private SpriteRenderer spriteRenderer;

    public void Randomize()
    {
        int index = Random.Range(0, pallete.Length);

        spriteRenderer.color = pallete[index].StoneColor;
    }
}
