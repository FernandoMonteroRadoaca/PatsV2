using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int money = 100;
    public float affection = 25f;
    public float hunger = 50f;

    public float affectionDecreaseRate = 1f; // units per second
    public float hungerDecreaseRate = 1f; // units per second

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        affection -= affectionDecreaseRate * Time.deltaTime;
        hunger -= hungerDecreaseRate * Time.deltaTime;

        affection = Mathf.Clamp(affection, 0, 100);
        hunger = Mathf.Clamp(hunger, 0, 100);
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;
    }

    public void DecreaseMoney(int amount)
    {
        money -= amount;
        money = Mathf.Max(money, 0); // Ensure money doesn't go below 0
    }

    public void IncreaseAffection(float amount)
    {
        affection += amount;
        affection = Mathf.Clamp(affection, 0, 100);
    }

    public void DecreaseAffection(float amount)
    {
        affection -= amount;
        affection = Mathf.Clamp(affection, 0, 100);
    }

    public void IncreaseHunger(float amount)
    {
        hunger += amount;
        hunger = Mathf.Clamp(hunger, 0, 100);
    }

    public void DecreaseHunger(float amount)
    {
        hunger -= amount;
        hunger = Mathf.Clamp(hunger, 0, 100);
    }
}
