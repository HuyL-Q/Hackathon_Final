using UnityEngine;
using UnityEngine.EventSystems;


public class TowerController : MonoBehaviour
{

    //int layerMarkMapTile;
    //int layerMarkTower;
    public static TowerController Instance { get; set; }

    //[SerializeField]
    //GameObject buyTowerPanel;
    //[SerializeField]
    //private GameObject upgradePanel;
    //[SerializeField]
    //private GameObject upgradePanel2;
    //[SerializeField]
    //private Text sellText;
    //[SerializeField]
    //private Text upgradeText;
    [SerializeField]
    LayerMask towerPlacementLayer;
    [SerializeField]
    LayerMask towerLayer;
    //private ATower selectedTower;
    //private Transform tilePosition;
    //private string nextLevelId;
    //RaycastHit2D hit;
    //RaycastHit2D hit2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //gameObject.AddComponent<ArcherTowerFactory>();
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
        //gameObject.AddComponent<ArcherTowerFactory>();
        //gameObject.AddComponent<CatapultTowerFactory>();
        //gameObject.AddComponent<HeroTowerFactory>();
        //layerMarkMapTile = ~LayerMask.GetMask("Tower"); //get the layer not Tower
        //layerMarkTower = ~LayerMask.GetMask("MapTile"); //get the layer not MapTile
    }


    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonUp(0) && GameController.instance.State != State.End_Defeat)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, towerPlacementLayer);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("TowerPlace"))
                {
                    //Debug.Log(hit.collider.transform.GetSiblingIndex());
                    StoryUIController.instance.OpenBuyTowerPanel(hit.collider.transform, hit.collider.transform.GetSiblingIndex());
                }
            }
            else
            {
                StoryUIController.instance.CloseBuyTower();
                hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, towerLayer);
                //Debug.Log(hit.collider);
                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Tower"))
                    {
                        StoryUIController.instance.OpenUpgrade_SellPanel(hit.collider.transform, hit.collider.transform.parent.gameObject);
                    }
                }
                else
                {
                    StoryUIController.instance.CloseUpgrade_SellPanel();
                }
            }
        }
        //if (!PlayerStats.EndGame)
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, layerMarkTower);
        //        hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, layerMarkMapTile);
        //        if (hit2 && hit2.collider.CompareTag("Map Tile (buildable)") && hit2.collider.GetComponent<TileCheck>().Flag)
        //        {

        //            if ((!UIManager.Instance.MenuStatus))
        //            {
        //                upgradePanel.SetActive(false);
        //                upgradePanel2.SetActive(false);

        //                UIManager.Instance.DisplayMenu();
        //                tilePosition = hit2.collider.transform;
        //            }
        //        }
        //        else
        //        {
        //            if (!EventSystem.current.IsPointerOverGameObject())
        //            {
        //                UIManager.Instance.CloseMenu();
        //                DeselectTower();
        //            }
        //        }

        //        if (hit && hit.collider.CompareTag("Tower"))
        //        {
        //            if (upgradePanel.activeInHierarchy)
        //            {
        //                upgradePanel.SetActive(false);
        //            }
        //            if (upgradePanel2.activeInHierarchy)
        //            {
        //                upgradePanel2.SetActive(false);
        //            }

        //            //RayCastHit2D: hit will take the Tower layer, hit2 will take  MapTile layer
        //            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, layerMarkTower);
        //            hit2 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity, layerMarkMapTile);
        //            SelectTower(hit.collider.gameObject.GetComponent<ATower>(), hit2, upgradePanel);
        //        }
        //        else
        //        {
        //            // Check if the mouse was clicked over a UI element, if not then deselect current tower
        //            if (!EventSystem.current.IsPointerOverGameObject())
        //            {
        //                DeselectTower();
        //            }
        //        }
        //    }
    }
    //private void SelectTower(ATower tower, RaycastHit2D h, GameObject upgradePanel)
    //{
    //    selectedTower = tower;
    //    //Check tower can upgrade more
    //    string[] s = selectedTower.ID.Split("_");
    //    nextLevelId = s[0] + "_" + s[1] + "_" + (int.Parse(s[2]) + 1);
    //    if (selectedTower.UpgradeTowerID(nextLevelId).Count > 0)
    //    {
    //        upgradePanel.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = true;
    //        upgradeText.text = "$" + selectedTower.GetNextCost(nextLevelId);
    //    }
    //    else
    //    {
    //        upgradePanel.transform.GetChild(0).gameObject.GetComponent<Button>().interactable = false;
    //    }

    //    selectedTower.gameObject.transform.GetChild(1).GetComponent<RangeIndicator>().Select(true);
    //    sellText.text = "+ " + (selectedTower.Price / 2).ToString();
    //    tilePosition = h.collider.GetComponent<TileCheck>().UpgradeAndSellTower(upgradePanel);
    //}
    //private void DeselectTower()
    //{
    //    if (selectedTower != null)
    //    {
    //        selectedTower.gameObject.transform.GetChild(1).GetComponent<RangeIndicator>().Select(false);
    //    }
    //    upgradePanel.SetActive(false);
    //    upgradePanel2.SetActive(false);
    //    selectedTower = null;
    //}
    //public bool CheckCost(string id)
    //{
    //    if (selectedTower.GetNextCost(id) > PlayerStats.Money) return false;
    //    return true;
    //}

    //public void SellTower()
    //{
    //    PlayerStats.Money += selectedTower.Price / 2;
    //    PlayerStats.UpdateUI();
    //    Destroy(selectedTower.transform.gameObject);
    //    tilePosition.gameObject.GetComponent<TileCheck>().SetTileStatus(true);
    //    upgradePanel.SetActive(false);
    //}
    //public void UpgradeTower()
    //{
    //    Debug.Log("Tower id: " + selectedTower.ID);
    //    List<string> id = new List<string>();
    //    string[] s = selectedTower.ID.Split("_");
    //    Debug.Log(s[0] + "_" + s[1] + "_" + (int.Parse(s[2]) + 1));
    //    nextLevelId = s[0] + "_" + s[1] + "_" + (int.Parse(s[2]) + 1);
    //    id = selectedTower.UpgradeTowerID(nextLevelId);
    //    switch (id.Count)
    //    {
    //        case 1:
    //            {
    //                if (CheckCost(nextLevelId))
    //                {
    //                    PlayerStats.Money -= selectedTower.GetNextCost(nextLevelId);
    //                    selectedTower.setTower(id[0]);
    //                    selectedTower.ChangeSprite(1);
    //                    PlayerStats.UpdateUI();
    //                }
    //                break;
    //            }
    //        case 2:
    //            {
    //                Debug.Log(upgradePanel.transform.position);
    //                upgradePanel.SetActive(false);
    //                hit = Physics2D.Raycast(selectedTower.transform.position, Vector3.zero, Mathf.Infinity, layerMarkTower);
    //                hit2 = Physics2D.Raycast(selectedTower.transform.position, Vector3.zero, Mathf.Infinity, layerMarkMapTile);
    //                DeselectTower();
    //                SelectTower(hit.collider.gameObject.GetComponent<ATower>(), hit2, upgradePanel2);

    //                //Change Sprite of button when upgrade 2 branch
    //                upgradePanel2.gameObject.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = selectedTower.GetUpgradeSprite(1);
    //                upgradePanel2.gameObject.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = selectedTower.GetUpgradeSprite(2);
    //                break;
    //            }
    //    }
    //    upgradePanel.SetActive(false);
    //}
    //public void UpgradeTower2(string id)
    //{
    //    if (CheckCost(nextLevelId + "_" + id))
    //    {
    //        PlayerStats.Money -= selectedTower.GetNextCost(nextLevelId + "_" + id);
    //        //set status of tower to next level and change the sprite to that level.
    //        selectedTower.setTower(nextLevelId + "_" + id);
    //        selectedTower.ChangeSprite(int.Parse(id));
    //        upgradePanel2.SetActive(false);
    //        PlayerStats.UpdateUI();
    //    }
    //    DeselectTower();
    //}
    //public static void getBuildTower(string id)
    //{
    //    switch (id)
    //    {
    //        case "tower_archer_1":
    //            Instance.BuildArcherTower(id);
    //            break;

    //        case "tower_catapult_1":
    //            Instance.BuildCatapultTower(id);
    //            break;
    //    }

    //}
    //public void BuildArcherTower(string id)
    //{
    //    if (PlayerStats.Money >= 70)
    //    {
    //        PlayerStats.Money -= 70;
    //        PlayerStats.UpdateUI();
    //        gameObject.GetComponent<ArcherTowerFactory>().TilePosition = tilePosition;
    //        gameObject.GetComponent<ArcherTowerFactory>().createTower(id);
    //        tilePosition.gameObject.GetComponent<TileCheck>().SetTileStatus(false);
    //    }
    //    GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
    //    foreach (GameObject tower in towers)
    //    {
    //        tower.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    //    }
    //    selectedTower = null;
    //}
    //public void BuildCatapultTower(string id)
    //{
    //    if (PlayerStats.Money >= 125)
    //    {
    //        //Debug.Log(id);
    //        //Debug.Log(tilePosition);
    //        PlayerStats.Money -= 125;
    //        PlayerStats.UpdateUI();
    //        gameObject.GetComponent<CatapultTowerFactory>().TilePosition = tilePosition;
    //        gameObject.GetComponent<CatapultTowerFactory>().createTower(id);
    //        tilePosition.gameObject.GetComponent<TileCheck>().SetTileStatus(false);
    //    }
    //    GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
    //    foreach (GameObject tower in towers)
    //    {
    //        tower.transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    //    }
    //    selectedTower = null;
    //}
}