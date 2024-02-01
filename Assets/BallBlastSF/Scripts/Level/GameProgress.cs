using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgress : MonoBehaviour
{
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    private void Awake()
    {
        Load();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("levelProgress:CurrentLevel", currentLevel);
    }

    private void Load()
    {
        currentLevel = PlayerPrefs.GetInt("levelProgress:CurrentLevel", 1);
    }

    public void GoToNextLevel()
    {
        currentLevel++;

        Save();
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif

#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif
}
