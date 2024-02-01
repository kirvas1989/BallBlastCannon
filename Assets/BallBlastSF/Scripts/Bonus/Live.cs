using UnityEngine;

public class Live : MonoBehaviour
{
    [SerializeField] public int CurrentLive;
    [SerializeField] AudioSource loseLiveAudio;
  
    private void Awake()
    {
        LoadAmountLive();
    }

    private void Update()
    {
        if (CurrentLive <= 0) CurrentLive = 0;
    }

    public void AddLive()
    {
        CurrentLive++;

        SaveAmountLive();

        return;
    }

    public void LoseLive()
    {
        CurrentLive--;

        loseLiveAudio.Play();

        SaveAmountLive();

        return;
    }

    public void SaveAmountLive()
    {
        if (CurrentLive > 0) PlayerPrefs.SetInt("Live:AmountLive", CurrentLive);
    }

    private void LoadAmountLive()
    {
        CurrentLive = PlayerPrefs.GetInt("Live:AmountLive", 3);
    }

}
