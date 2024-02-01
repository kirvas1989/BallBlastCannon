using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public int maxHitPoints;

    [HideInInspector] public UnityEvent Die;
    [HideInInspector] public UnityEvent ChangeHitPoints;
    
    private int hitPoints;
    private bool isDie = false;

    private void Awake()
    {
        LoadMaxHitPoints();
    }

    private void Start()
    {
        hitPoints = maxHitPoints;
        ChangeHitPoints.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        hitPoints -= damage;

        ChangeHitPoints.Invoke();

        if (hitPoints <= 0)
        {
            Kill();
        }
    } 

    public void Kill() 
    {
        if (isDie == true) return;      
        hitPoints = 0;
        isDie = true;

        ChangeHitPoints.Invoke();
        Die.Invoke();
    }

    public int GetHitPoints()
    {
        return hitPoints;
    }

    public void AddMaxHitPoints()
    {
        maxHitPoints++;
        SaveMaxHitPoints();
        return;
    }

    public void SaveMaxHitPoints()
    {
        PlayerPrefs.SetInt("Destructible:MaxHitPoints", maxHitPoints);
    }

    private void LoadMaxHitPoints()
    {
        maxHitPoints = PlayerPrefs.GetInt("Destructible:MaxHitPoints", 4);
    }
}