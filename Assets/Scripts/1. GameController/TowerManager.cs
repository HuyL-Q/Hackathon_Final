using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower
{
    public string id;
    public int attack;
    public float attackSpeed;
    public float range;
    public string[] Special;
    public int Cost;
    public int width;
    public int height;
    public string bulletID;
}

public class TowerPriceConverter : JsonConverter<List<Tower>> { }
public class TowerManager : MonoBehaviour
{
    [SerializeField]
    GameObject towerPlacementParent;
    [SerializeField]
    GameObject btnBuyArcher;
    [SerializeField]
    Transform towerParent;
    int archerPrice;
    ArcherTowerFactory archerTowerFactory;
    public static TowerManager instance;
    public int ArcherPrice { get => archerPrice; set => archerPrice = value; }
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
        archerTowerFactory = GetComponent<ArcherTowerFactory>();
        FetchTowerPrice();
    }

    void FetchTowerPrice()
    {
        TowerPriceConverter converter = new();
        converter.setCurrentDir(@"\Assets\JSON\TowerStat.json");
        List<Tower> towers = converter.getObjectFromJSON();
        foreach (Tower tower in towers)
        {
            if (tower.id.Contains("archer_1"))
            {
                ArcherPrice = tower.Cost;
                btnBuyArcher.transform.GetChild(0).GetComponent<Text>().text = ArcherPrice.ToString();
            }
        }
    }

    public void SetTower(int placementIndex)
    {
        Transform towerPlace = towerPlacementParent.transform.GetChild(placementIndex);
        Vector3 pos = towerPlace.position;
        pos.x += 1f;
        pos.y -= .75f;
        archerTowerFactory.GetComponent<ArcherTowerFactory>().CreateTower(towerParent, pos, placementIndex);
        towerPlace.gameObject.SetActive(false);
        GameController.instance.PlayerMoney -= ArcherPrice;
        StoryUIController.instance.UpdateGoldIndex();
    }
}
