using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Pool;

public class Heroes : MonoBehaviour
{
    private int placementIndex;
    private float maxHP;
    private float hp;
    private float atkDamage;
    private float atkSpeed;
    [SerializeField]
    GameObject _arrow;
    Transform shootingPosition;
    private ObjectPool<GameObject> objectPool;
    Animator _animator;
    GameObject currentEnemy;
    [SerializeField]
    GameObject healthBar;

    public float HP
    {
        get => hp;
        set
        {
            hp = value;
            healthBar.GetComponent<SpriteRenderer>().size = new((float)(HP * 1.28) / maxHP, 0.16f);
            if (hp <= 0) Destroy(transform.GetChild(1).gameObject);
        }
    }

    public float AtkDamage { get => atkDamage; set => atkDamage = value; }
    public float AtkSpeed { get => atkSpeed; set => atkSpeed = value; }
    public int PlacementIndex { get => placementIndex; set => placementIndex = value; }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        currentEnemy = GameObject.FindGameObjectWithTag("Boss");
        objectPool = new(() => Instantiate(_arrow),
                        obj => obj.SetActive(true),
                        obj => obj.SetActive(false),
                        obj => Destroy(obj),
                        false,
                        10,
                        20);
        shootingPosition = transform.GetChild(0);
        SetStatus();
    }
    public class StatConverter : JsonConverter<FinalStat>{}
    void SetStatus()
    {
        StatConverter stat = new StatConverter();
        stat.setCurrentDir(@"\FinalStat.json");
        FinalStat fs = stat.getObjectFromJSON();
        maxHP = fs.Health;
        HP = maxHP;
        AtkDamage = fs.Attack;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventController.Instance.State == State.Start)
        {
            _animator.SetInteger("State", (int)State.Start);
            _animator.SetBool("hasEnemy", currentEnemy != null);
        }
        if (HP <= 0 || EventController.Instance.State == State.End_Defeat)
        {
            _animator.SetTrigger("Dead");
        }
    }

    public void AfterDeath()
    {
        HeroesManager.instance.TowerPlacement.GetChild(PlacementIndex).gameObject.SetActive(true);
        Destroy(gameObject);
    }

    public void ReceiveDamage(float dmg)
    {
        HP -= dmg;
    }
    public void Attack()
    {
        GameObject arrowGO = objectPool.Get();
        arrowGO.transform.position = shootingPosition.transform.position;
        //arrowGO.transform.localScale = transform.localScale;
        arrowGO.GetComponent<Arrow>().Damage = atkDamage;
        arrowGO.GetComponent<Arrow>().TargetAiming = currentEnemy;
        arrowGO.GetComponent<Arrow>().OnRelease = obj => objectPool.Release(obj);
    }
}
