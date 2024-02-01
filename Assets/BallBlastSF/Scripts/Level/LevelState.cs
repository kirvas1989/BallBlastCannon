using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private UILevelProgress levelProgress; 
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;
    [SerializeField] private CartInputControl controls;
    [SerializeField] private Projectile projectile;
    [SerializeField] private UIGamePanel gamePanel;
    [SerializeField] private Live live;
    [SerializeField] private StoneSpawner stoneSpawner;
    [SerializeField] private Destructible stonePrefab; 

    private List<StoneMovement> stoneMovements = new();
    private StoneMovement[] stoneMovementArray;

    private List<CoinMovement> coinMovements = new();
    private CoinMovement[] coinMovementArray;

    private ScoresCollector scoresCollector;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;

    private void Awake()
    {
        GameObject scores = GameObject.FindGameObjectWithTag("Scores");
        scoresCollector = scores.GetComponent<ScoresCollector>();

        spawner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnCartCollisionStone);

        SetAllActivities(false);
    }

    public void StartGame()
    {
        SetAllActivities(true);

        gamePanel.HideUI();       
    }

    private void OnDestroy()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        live.LoseLive();
        
        if (live.CurrentLive < 1)
        {
            Defeat.Invoke();
            gamePanel.LevelDefeated();
            SetAllActivities(false);
        }  
    }

    private void OnSpawnCompleted()
    {
        checkPassed = true;        
    }

    private void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > 0.5f)
        {
            if (checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {                                   
                    Passed.Invoke();

                    levelProgress.ProgressBarUpdate();
                    scoresCollector.CheckForHighScores();
                    gamePanel.LevelPassed();
                    live.SaveAmountLive();
                    stoneSpawner.AddSpawnAmount(); 
                    stonePrefab.AddMaxHitPoints(); 
                    enabled = false; 
                }
            }

            timer = 0;
        }                 
    }

    private void SetAllActivities(bool set)
    {       
        controls.enabled = set;
        cart.enabled = set;
        projectile.enabled = set;       
        spawner.enabled = set;

        stoneMovementArray = FindObjectsOfType<StoneMovement>();
        foreach (StoneMovement stoneMovement in stoneMovementArray)
        {
            stoneMovements.Add(stoneMovement);
        }

        for (int i = 0; i < stoneMovementArray.Length; i++)
        {
            stoneMovementArray[i].enabled = set;
        }

        coinMovementArray = FindObjectsOfType<CoinMovement>();
        foreach (CoinMovement coinMovement in coinMovementArray)
        {
            coinMovements.Add(coinMovement);
        }

        for (int i = 0; i < coinMovementArray.Length; i++)
        {
            coinMovementArray[i].enabled = set;
        }
    }
}
