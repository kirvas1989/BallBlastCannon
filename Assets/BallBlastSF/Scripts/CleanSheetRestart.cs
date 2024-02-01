using UnityEngine;
using UnityEngine.SceneManagement;

public class CleanSheetRestart : MonoBehaviour
{
    [SerializeField] private Live live;

    public void CleanRestart()
    {
        if (live.CurrentLive == 0)
        {
            PlayerPrefs.DeleteKey("Haste:AmountHaste");
            PlayerPrefs.DeleteKey("Live:AmountLive");
            PlayerPrefs.DeleteKey("Power:AmountPower");
            PlayerPrefs.DeleteKey("Weapon:AmountWeapon");

            //PlayerPrefs.DeleteKey("Bag:AmountCoins");

            PlayerPrefs.DeleteKey("Destructible:MaxHitPoints");
            PlayerPrefs.DeleteKey("StoneSpawner:SpawnAmount");

            PlayerPrefs.DeleteKey("levelProgress:CurrentLevel");
            //PlayerPrefs.DeleteKey("ScoresCollector:MaxScores");

            //PlayerPrefs.DeleteAll();
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
