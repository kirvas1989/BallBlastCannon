using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [SerializeField] private UILevelProgress levelProgress;
    
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;

    [Header("Balance")]
    [SerializeField] private Turret turret;
    [SerializeField] public int SpawnAmount;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitPointsPercentage;
    [SerializeField] private float maxHitPointsRate;

    [Space(10)] public UnityEvent Completed;

    private StoneColor stoneColor;

    private Vector3 offset;
    private Vector3 addOffset;

    private float timer;
    private int amountSpawned;
    private int stoneMaxHitPoints;
    private int stoneMinHitPoints;


    private void Awake()
    {
        stoneColor = stonePrefab.GetComponent<StoneColor>();

        offset = new Vector3(0, 0, 0.0001f);

        addOffset = new Vector3(0, 0, 0.0001f);
    }

    private void Start()
    {
        int damagePerSecond = (int)(turret.Damage * turret.ProjectileAmount * (1 / turret.Firerate));

        stoneMaxHitPoints = (int)(damagePerSecond * maxHitPointsRate);
        stoneMinHitPoints = (int)(stoneMaxHitPoints * minHitPointsPercentage);

        timer = spawnRate;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            Spawn();

            timer = 0;

            if (amountSpawned > 1) levelProgress.ProgressBarUpdate();
        }

        if (amountSpawned == SpawnAmount)
        {
            enabled = false;

            Completed.Invoke();
        }
    }

    private void Spawn()
    {
        if (Freeze.FreezeActivated == false)
        {
            stoneColor.Randomize();

            Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            stone.SetSize((Stone.Size)Random.Range(1, 4));
            stone.maxHitPoints = Random.Range(stoneMinHitPoints, stoneMaxHitPoints + 1);
            stone.transform.position += offset;

            offset += addOffset;

            amountSpawned++;
        }
    }

    public void AddSpawnAmount()
    {
        SpawnAmount++;

        SaveSpawnAmount();

        return;
    }

    public void SaveSpawnAmount()
    {
        PlayerPrefs.SetInt("StoneSpawner:SpawnAmount", SpawnAmount);
    }

    private void LoadSpawnAmount()
    {
        SpawnAmount = PlayerPrefs.GetInt("StoneSpawner:SpawnAmount", 4);
    }

}
