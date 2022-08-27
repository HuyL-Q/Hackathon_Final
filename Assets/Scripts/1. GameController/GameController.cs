using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class PlayerStat
{
    private int health;
    private int money;

    public PlayerStat(int health, int money)
    {
        this.health = health;
        this.money = money;
    }

    public int Lives { get => health; set => health = value; }
    public int Money { get => money; set => money = value; }


}
public class PlayerStatsConverter : JsonConverter<PlayerStat> { }
public class GameController : MonoBehaviour
{
    int playerLives;
    float playerMoney;
    float playerPoint;
    State state;

    public int PlayerLives { get => playerLives; set => playerLives = value; }
    public float PlayerMoney { get => playerMoney; set => playerMoney = value; }
    public float PlayerPoint { get => playerPoint; set => playerPoint = value; }
    public State State { get => state; set => state = value; }

    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        State = State.Prestart;
        ReadStatFromFile();
    }

    void ReadStatFromFile()
    {
        PlayerStatsConverter statsConverter = new();
        statsConverter.setCurrentDir(@"\PlayerStats.json");
        PlayerStat stats = statsConverter.getObjectFromJSON();
        PlayerLives = stats.Lives;
        PlayerMoney = stats.Money;
        PlayerPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerLives <= 0)
        {
            State = State.End_Defeat;
            Time.timeScale = 0;
        }
    }
}