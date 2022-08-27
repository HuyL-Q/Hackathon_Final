using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //[Header("Game Over")]
    //public TMP_Text levelText;
    //public Text scoreText;
    //public GameObject canvas;

    //[Header("Pause Menu")]
    //public GameObject PauseOption;
    //[SerializeField]
    //GameObject VolSettingCanvas;

    //[Header("Player Status")]
    //[SerializeField]
    //private Text goldText;
    //[SerializeField]
    //private Text liveText;
    //[SerializeField]
    //private Text waveIndex;
    //[SerializeField]
    //private Text speedUpText;
    //[Header("Tower UI")]
    //[SerializeField] private Transform ScrollPanel;
    //[SerializeField] private GameObject TowerOption;
    //[SerializeField] private GameObject BuyTowerMenuGO;

    public static UIManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    //public bool MenuStatus
    //{
    //    get { return BuyTowerMenuGO.activeSelf; }
    //}
    //public Text WaveIndex
    //{
    //    get { return waveIndex; }
    //    set { waveIndex = value; }
    //}
    //public Text GoldText
    //{
    //    get { return goldText; }
    //    set { goldText = value; }
    //}
    //public Text LiveText
    //{
    //    get { return liveText; }
    //    set { liveText = value; }
    //}

    //public Text SpeedUpText { get => speedUpText; set => speedUpText = value; }

    //public void ADS()
    //{
    //    Debug.Log("Hello ADS!");
    //}
    //public void SetLevel(string txt)
    //{
    //    if (levelText != null)
    //        levelText.text = txt;
    //}
    //public void ShowCanvas(bool endGame)
    //{
    //    if (canvas)
    //    {
    //        canvas.SetActive(endGame);
    //        if (!PlayerPrefs.HasKey("HighScore"))
    //        {
    //            PlayerPrefs.SetFloat("HighScore", Mathf.Ceil(PlayerStats.Point));
    //        }
    //        else
    //        {
    //            if (PlayerPrefs.GetFloat("HighScore") < Mathf.Ceil(PlayerStats.Point))
    //            {
    //                PlayerPrefs.SetFloat("HighScore", Mathf.Ceil(PlayerStats.Point));
    //            }
    //        }
    //        scoreText.text = PlayerPrefs.GetFloat("HighScore").ToString();
    //    }
    //}
    //public void SpeedUp()
    //{
    //    if (!PlayerStats.EndGame)
    //        switch (PlayerStats.GameSpeed)
    //        {
    //            case 1:
    //                PlayerStats.GameSpeed = 15f;
    //                SpeedUpText.text = PlayerStats.GameSpeed.ToString() + "x";
    //                break;
    //            case 15f:
    //                PlayerStats.GameSpeed = 2;
    //                SpeedUpText.text = PlayerStats.GameSpeed.ToString() + "x";
    //                break;
    //            case 2:
    //                PlayerStats.GameSpeed = 1;
    //                SpeedUpText.text = PlayerStats.GameSpeed.ToString() + "x";
    //                break;
    //        }
    //}
    //public void Pause()
    //{
    //    PlayerStats.GameSpeed = 0;
    //    PauseOption.SetActive(true);
    //}
    //public void Resume()
    //{
    //    PlayerStats.GameSpeed = 1;
    //    SpeedUpText.text = PlayerStats.GameSpeed.ToString() + "x";
    //    PauseOption.SetActive(false);
    //}
    //public void Replay()
    //{
    //    this.canvas.SetActive(false);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
    //public void Exit()
    //{
    //    MenuManager.MenuSwitch(MenuName.Main);
    //}
    //public void OpenSetting()
    //{
    //    Instantiate(VolSettingCanvas);
    //}
    //public class JsonString
    //{
    //    public string type;
    //}
    //public class stringConverter : JsonConverter<List<JsonString>> { }
    void Start()
    {
        //stringConverter ct = new stringConverter();
        //ct.setCurrentDir(@"\Assets\JSON\BuyTower.json");
        //List<JsonString> coverterList = ct.getObjectFromJSON();
        //Transform left = ScrollPanel.GetChild(0).transform;
        //Transform right = ScrollPanel.GetChild(1).transform;
        //bool flag = false;
        //foreach (JsonString coverter in coverterList)
        //{
        //    GameObject button = (GameObject)Instantiate(TowerOption, ScrollPanel);
        //    Button btn = button.GetComponent<Button>();
        //    btn.name = coverter.type;
        //    btn.image.sprite = Resources.Load<Sprite>("Prefabs/TowerSprites/" + coverter.type);
        //    btn.onClick.AddListener(delegate { CreateTower(coverter.type); });
        //    RectTransform brt = button.GetComponent<RectTransform>();
        //    brt.sizeDelta = new Vector2(200, 200);
        //    if (flag)
        //    {
        //        button.transform.SetParent(left);
        //        flag = !flag;
        //    }
        //    else
        //    {
        //        button.transform.SetParent(right);
        //        flag = !flag;
        //    }
        //}
        //BuyTowerMenuGO.SetActive(false);
    }
    //public void CreateTower(string id)
    //{
    //    TowerController.getBuildTower(id);
    //    CloseMenu();
    //}
    //public void DisplayMenu()
    //{
    //    Vector2 position = ScrollPanel.gameObject.GetComponent<RectTransform>().position;
    //    position.y = -520;
    //    ScrollPanel.gameObject.GetComponent<RectTransform>().position = position;
    //    BuyTowerMenuGO.SetActive(true);
    //}
    //public void CloseMenu()
    //{
    //    BuyTowerMenuGO.SetActive(false);
    //}
}
