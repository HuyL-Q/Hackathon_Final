using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    //private static int money;
    //private static int lives;
    //private static float point;
    //private static bool endGame = false;
    //private static float gameSpeed = 1;
    //static UIManager UI;

    //public static int Money { get => money; set => money = value; }
    //public static int Lives { get => lives; set => lives = value; }
    //public static float Point { get => point; set => point = value; }
    //public static bool EndGame { get => endGame; set => endGame = value; }
    //public static float GameSpeed { get => gameSpeed; set => gameSpeed = value; }

    //// Start is called before the first frame update

    //public class Castle
    //{
    //    public int health;
    //    public int money;
    //}
    //public class CastleConverter : JsonConverter<Castle> { }
    void Start()
    {
        //endGame = false;
        //gameSpeed = 1;
        //CastleConverter castleConverter = new CastleConverter();
        //castleConverter.setCurrentDir(@"\Assets\JSON\PlayerStats.json");
        //UI = FindObjectOfType<UIManager>();
        //Castle castle = castleConverter.getObjectFromJSON();
        //Money = castle.money;
        //Lives = castle.health;
        //point = 0f;
        //UI.PauseOption.SetActive(false);
        //UI.SpeedUpText.text = gameSpeed.ToString() + "x";
        //UI.GoldText.text = Money.ToString();
        //UI.LiveText.text = Lives.ToString();
        //UI.WaveIndex.text = SpawnController.WaveIndex.ToString();
    }
    void Update()
    {
        //UI.SetLevel("" + PlayerStats.Point);
        //Time.timeScale = GameSpeed;
        //UI.ShowCanvas(endGame);
        //if (Lives <= 0)
        //{
        //    Time.timeScale = 0;
        //    endGame = true;
        //}
    }
    //public void Replay()
    //{
    //    UI.canvas.SetActive(false);
    //    Time.timeScale = 1.0f;
    //    SceneManager.LoadScene("Gameplay");
    //}
    //public static void UpdateUI()
    //{
    //    UI.GoldText.text = Money.ToString();
    //    UI.LiveText.text = Lives.ToString();
    //    UI.WaveIndex.text = SpawnController.WaveIndex.ToString();
    //}
}
