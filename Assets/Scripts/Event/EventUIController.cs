using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventUIController : MonoBehaviour
{
    [SerializeField]
    GameObject inGamePanel;
    [SerializeField]
    GameObject buyCircle;
    [SerializeField]
    Image healthBar;
    [SerializeField]
    Text timer;
    [SerializeField]
    Button playButton;
    [SerializeField]
    GameObject endScreen;
    [SerializeField]
    GameObject setHeroButton;
    [SerializeField]
    GameObject setHeroCooldown;
    [SerializeField]
    int placementIndex;
    private bool isGameOver;
    float startTiming = 3;
    public static EventUIController instance;

    public GameObject SetHeroCooldown { get => setHeroCooldown; set => setHeroCooldown = value; }
    public Image HealthBar { get => healthBar; set => healthBar = value; }

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
        inGamePanel.SetActive(true);
        DisplayTime(EventController.Instance.ActiveTimer);
        isGameOver = false;
        playButton.onClick.AddListener(StartGame);
        StartCoroutine(OnBossIntro());
    }

    IEnumerator OnBossIntro()
    {
        playButton.interactable = false;
        yield return new WaitForSeconds(startTiming + 0.5f);
        playButton.interactable |= true;
        StopCoroutine(OnBossIntro());
    }
    void StartGame()
    {
        EventController.Instance.State = State.Start;
        playButton.interactable = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (EventController.Instance.State == State.Start)
        {
            DisplayTime(EventController.Instance.ActiveTimer);
            if (HeroesManager.instance.CooldownTimer > 0)
            {
                setHeroButton.GetComponent<Button>().interactable = false;
                //DisplayCooldownSetHero();
            }
            else
            {
                setHeroButton.GetComponent<Button>().interactable = true;
                //SetHeroCooldown.GetComponent<Image>().fillAmount = 0;
            }            
        }
        if ((EventController.Instance.State == State.End_Defeat || EventController.Instance.State == State.End_Victory) && !isGameOver)
        {
            isGameOver = true;
            ShowResult();
        }
    }
    void DisplayTime(float timeDisplay)
    {
        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);
        timer.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
    public void DisplayCooldownSetHero(float timer)
    {
        SetHeroCooldown.GetComponent<Image>().fillAmount = 1;
        SetHeroCooldown.GetComponent<Image>().DOFillAmount(0, timer).SetEase(Ease.Linear);
    }
    void ShowResult()
    {
        Instantiate(endScreen);
        if(EventController.Instance.State == State.End_Defeat)
        {
            //var endScreenChild = endScreen.transform.GetChild(0);
            endScreen.transform.GetChild(0).GetChild(0).GetComponent<Image>().DOColor(Color.red, 0.5f).SetUpdate(true);
            endScreen.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Defeat";
            Debug.Log(EventController.Instance.DmgDealed);
            endScreen.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Damage: " + EventController.Instance.DmgDealed.ToString();
        }
        else
        {
            //var endScreenChild = endScreen.transform.GetChild(0);
            endScreen.transform.GetChild(0).GetChild(0).GetComponent<Image>().DOColor(Color.green, 0.5f).SetUpdate(true);
            endScreen.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Victory";
            string str = "Damage: " + EventController.Instance.DmgDealed.ToString();
            endScreen.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = str;
        }
    }
    public void OpenBuyCircle(Transform targetPos, int placementIndex)
    {
        CloseBuyCircle();
        //Debug.Log(Camera.main.WorldToScreenPoint(targetPos.position));
        Vector3 offset = targetPos.GetComponent<BoxCollider2D>().offset;
        buyCircle.transform.position = new(targetPos.position.x + offset.x, targetPos.position.y + offset.y, buyCircle.transform.position.z);
        buyCircle.transform.localScale = new(0, 0, 0);
        buyCircle.SetActive(true);
        buyCircle.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack);
        this.placementIndex = placementIndex;
    }
    public void CloseBuyCircle()
    {
        buyCircle.transform.DOKill();
        buyCircle.SetActive(false);
        //placementIndex = -1;
    }
    public void ButtonSetHero()
    {
        CloseBuyCircle();
        HeroesManager.instance.SetHero(placementIndex);
    }

    public void SetValueHealthBar(float value)
    {
        //HealthBar.fillAmount = value;
        HealthBar.DOFillAmount(value, 1f);
    }
}
