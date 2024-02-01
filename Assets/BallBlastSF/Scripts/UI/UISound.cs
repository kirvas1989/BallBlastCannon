using UnityEngine;

public class UISound : MonoBehaviour
{
    public AudioSource clickSound;

    public void playClickSound()
    {
        clickSound.Play();
    }
}