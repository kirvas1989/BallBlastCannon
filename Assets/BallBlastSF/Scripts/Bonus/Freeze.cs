using UnityEngine;

public class Freeze : MonoBehaviour
{
    [SerializeField] private SpriteRenderer frostSprite;
    [SerializeField] public float freezeTimer;
    [SerializeField] public float timerLeft;
    [SerializeField] public static bool FreezeActivated;

    private void Awake()
    {
        ResetFreeze();
    }

    private void Update()
    {
        if (FreezeActivated == true)
        {
            timerLeft -= Time.deltaTime;

            if (timerLeft <= 0)
            {
                ResetFreeze();
            }
        }
    }

    private void ResetFreeze()
    {
        FreezeActivated = false;

        frostSprite.enabled = false;

        timerLeft = 0;
    }

    public void AddFreeze()
    {
        FreezeActivated = true;

        frostSprite.enabled = true;

        timerLeft = freezeTimer;
    }
}
