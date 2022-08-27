using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    [SerializeField]
    GameObject heroPrefab;
    [SerializeField]
    Transform towerPlacement;
    [SerializeField]
    Transform towerParent;
    private float cooldownTimer;
    public static HeroesManager instance;

    public float CooldownTimer { get => cooldownTimer; set => cooldownTimer = value; }
    public Transform TowerPlacement { get => towerPlacement; set => towerPlacement = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (CooldownTimer > 0)
        {
            CooldownTimer -= Time.deltaTime;
        }
    }

    public void SetHero(int placementIndex)
    {
        Transform towerPlacementIndex = TowerPlacement.GetChild(placementIndex);
        GameObject hero = Instantiate(heroPrefab, towerParent);
        //Debug.Log(towerPlacementIndex.position);
        Vector3 offset = towerPlacementIndex.GetComponent<BoxCollider2D>().offset;
        Vector3 pos = towerPlacementIndex.position;
        pos.x += offset.x / 2;
        pos.y -= offset.y / 2;
        hero.transform.position = pos;
        hero.GetComponent<Heroes>().PlacementIndex = placementIndex;
        towerPlacementIndex.gameObject.SetActive(false);
        if (EventController.Instance.State == State.Start)
        {
            CooldownTimer = 15;
            EventUIController.instance.DisplayCooldownSetHero(CooldownTimer);
        }
    }
}
