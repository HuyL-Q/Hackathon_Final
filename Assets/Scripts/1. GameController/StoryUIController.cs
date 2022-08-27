using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerType
{
    public string towerType;
}

public class StringConverter : JsonConverter<List<TowerType>> { }
public class StoryUIController : MonoBehaviour
{
    private float currentTimeScale;
    private int placementIndex;
    [SerializeField]
    GameObject speedUpGO;
    [SerializeField]
    GameObject livesGO;
    [SerializeField]
    GameObject goldGO;
    [SerializeField]
    GameObject waveGO;
    [SerializeField]
    GameObject buyTowerPanel;
    public static StoryUIController instance;

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
        UpdateLivesIndex();
        UpdateGoldIndex();
        UpdateWaveIndex();
    }
    public void SpeedUp()
    {
        switch (Time.timeScale)
        {
            case 1:
                Time.timeScale = 2;
                speedUpGO.transform.GetChild(0).gameObject.SetActive(false);
                speedUpGO.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 2:
                Time.timeScale = 5;
                speedUpGO.transform.GetChild(1).gameObject.SetActive(false);
                speedUpGO.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 5:
                Time.timeScale = 1;
                speedUpGO.transform.GetChild(2).gameObject.SetActive(false);
                speedUpGO.transform.GetChild(0).gameObject.SetActive(true);
                break;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWaveIndex()
    {
        waveGO.GetComponentInChildren<Text>().text = NewSpawnController.Instance.WaveIndex.ToString();
    }

    public void UpdateLivesIndex()
    {
        livesGO.GetComponentInChildren<Text>().text = GameController.instance.PlayerLives.ToString();
    }

    public void UpdateGoldIndex()
    {
        goldGO.GetComponentInChildren<Text>().text = GameController.instance.PlayerMoney.ToString();
    }

    public void OpenBuyTowerPanel(Transform towerPlacement, int towerPlacementIndex)
    {
        CloseBuyTower();
        buyTowerPanel.SetActive(true);
        //Vector3 offset = towerPlacement.GetComponent<PolygonCollider2D>().offset;
        buyTowerPanel.transform.position = new(towerPlacement.position.x + 1f, towerPlacement.position.y - .75f, buyTowerPanel.transform.position.z);
        buyTowerPanel.transform.localScale = new(0, 0, 0);
        buyTowerPanel.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        placementIndex = towerPlacementIndex;
    }

    public void CloseBuyTower()
    {
        buyTowerPanel.transform.DOKill();
        buyTowerPanel.SetActive(false);
    }

    public void BuildTower(int index)
    {
        CloseBuyTower();
        switch (index)
        {
            case 1:
                TowerManager.instance.SetTower(placementIndex);
                break;
        }
    }

    public void PauseButton()
    {
        currentTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }
}
