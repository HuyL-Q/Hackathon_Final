using UnityEngine;
using UnityEngine.EventSystems;

public enum State { Prestart, Start, End_Defeat, End_Victory, Pause };

public class EventController : MonoBehaviour
{
    [SerializeField]
    LayerMask towerPlaceLayer;
    [SerializeField]
    public GameObject spawnPosition;
    [SerializeField]
    GameObject bossPrefab;
    private int dmgDealed;
    private float activeTimer;
    private State state;
    public State State { get { return state; } set { state = value; } }
    public static EventController Instance { get; set; }
    public float ActiveTimer { get => activeTimer; set => activeTimer = value; }
    public int DmgDealed { get => dmgDealed; set => dmgDealed = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        state = State.Prestart;
        ActiveTimer = 90;
        DmgDealed = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bossPrefab, new(-10, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (State == State.Start)
        {
            ActiveTimer -= Time.deltaTime;
        }
        if (ActiveTimer < 1)
        {
            State = State.End_Defeat;
        }
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, towerPlaceLayer);
            if (hit.collider != null)
            {
                //Debug.Log(hit.collider.transform);
                if (hit.collider.CompareTag("TowerPlace"))
                {
                    EventUIController.instance.OpenBuyCircle(hit.collider.transform, hit.collider.transform.GetSiblingIndex());
                }
            }
            else
            {
                EventUIController.instance.CloseBuyCircle();
            }
        }
    }
}