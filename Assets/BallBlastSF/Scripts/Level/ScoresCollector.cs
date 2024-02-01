using UnityEngine;

public class ScoresCollector : MonoBehaviour
{
    [SerializeField] private GameProgress levelProgress;
    [SerializeField] private int scores;
    [SerializeField] private int maxScores;
  
    public int Scores => scores;  
    public int MaxScores => maxScores;


    private void Awake()
    {
        LoadMaxScores();
    }

    public void AddSores(int currentScore) 
    {        
        scores += currentScore; 
    }

    public void CheckForHighScores()
    {
        if (scores > maxScores)
        {
            maxScores = scores;

            SaveMaxScores();
        }
    }

    private void SaveMaxScores()
    {
        PlayerPrefs.SetInt("ScoresCollector:MaxScores", maxScores);           
    }

    private void LoadMaxScores()
    {
        maxScores = PlayerPrefs.GetInt("ScoresCollector:MaxScores", 0);
    }
}
