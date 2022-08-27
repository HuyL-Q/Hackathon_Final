using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class ATower : MonoBehaviour, ITower
{
    private int placementIndex;
    [SerializeField]
    GameObject bullet;
    //[SerializeField]
    //private Sprite[] towerUgradeSprites;
    [SerializeField]
    List<GameObject> monsters;
    [SerializeField]
    GameObject rangeIndicator;
    private string id;
    private int damage;
    private float range;
    [SerializeField]
    private double attackSpeed;
    private int price;
    private int size;
    private List<String> special;
    private Vector3 shootPosition;
    private GameObject currentEnemy;
    public ObjectPool<GameObject> objectPool;
    private double shootTimer;
    private int spriteIndex;
    List<TowerJs> idList = new List<TowerJs>();
    public string ID
    {
        get { return id; }
        set { id = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float Range
    {
        get { return range; }
        set { range = value; }
    }
    public double AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
    }
    public int Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Size
    {
        get { return size; }
        set { size = value; }
    }
    public Vector3 ShootPosition
    {
        get { return shootPosition; }
        set { shootPosition = value; }
    }
    public GameObject CurrentEnemy
    {
        get { return currentEnemy; }
        set { currentEnemy = value; }
    }
    public List<string> Special { get => special; set => special = value; }
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    public List<TowerJs> IdList { get => idList; set => idList = value; }
    public int PlacementIndex { get => placementIndex; set => placementIndex = value; }
    public GameObject RangeIndicator { get => rangeIndicator; }

    public class TowerJs
    {
        public string id;
        public int attack;
        public double attackSpeed;
        public float range;
        private List<string> special;
        private int cost;
        public int width;
        public int height;
        public string bulletID;//Not in use currently

        public int Cost { get => cost; set => cost = value; }
        public List<string> Special { get => special; set => special = value; }
        public TowerJs(string id, int attack, double attackSpeed, float range, List<string> special, int cost, int width, int height, string bulletID)
        {
            this.id = id;
            this.attack = attack;
            this.attackSpeed = attackSpeed;
            this.range = range;
            this.special = special;
            this.cost = cost;
            this.width = width;
            this.height = height;
            this.bulletID = bulletID;
        }
    }
    //public virtual void ChangeSprite(int i)
    //{
    //    SpriteIndex += i;
    //    gameObject.GetComponent<SpriteRenderer>().sprite = towerUgradeSprites[SpriteIndex];
    //}
    //public virtual Sprite GetUpgradeSprite(int i)
    //{
    //    return towerUgradeSprites[SpriteIndex + i];
    //}
    public abstract IEnumerator SetTower(string id);
    public virtual void Attack()
    {
        //Vector3.
        GameObject arrowGO = objectPool.Get();
        arrowGO.transform.localScale = new(5, 5, 5);
        arrowGO.transform.position = ShootPosition;
        //arrowGO.transform.localScale = transform.localScale;
        arrowGO.GetComponent<Arrow>().Damage = Damage;
        arrowGO.GetComponent<Arrow>().TargetAiming = CurrentEnemy;
        arrowGO.GetComponent<Arrow>().OnRelease = obj => objectPool.Release(obj);
    }
    public abstract int GetSize();
    public virtual int GetNextCost(string id)
    {
        int nextLevelCost = 0;
        foreach (TowerJs i in IdList)
        {
            if (i.id.Contains(id))
                nextLevelCost = i.Cost;
        }
        return nextLevelCost;
    }
    public virtual List<string> UpgradeTowerID(string id)
    {
        //get id of tower need to upgrade
        List<string> idU = new List<string>();
        foreach (TowerJs i in IdList)
        {
            if (i.id.Contains(id))
            {
                idU.Add(i.id);
            }
        }
        return idU;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Minions"))
        {
            monsters.Add(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Minions"))
        {
            GameObject monster = collision.gameObject;
            if (monster.GetComponent<Minions>().HP <= 0)
            {
                monsters.Remove(monster);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Minions"))
        {
            monsters.Remove(collision.gameObject);
        }
    }

    public virtual void UpdateEnemy()
    {
        if (monsters.Count > 0)
        {
            CurrentEnemy = monsters[0];
        }
        else
        {
            CurrentEnemy = null;
        }
    }

    public virtual void Start()
    {
        monsters = new();
        shootTimer = AttackSpeed;
        objectPool = new ObjectPool<GameObject>(() => { return Instantiate(bullet); }
                                                , obj => { obj.SetActive(true); }
                                                , obj => { obj.SetActive(false); }
                                                , obj => { Destroy(obj); }
                                                , false
                                                , 10
                                                , 20);
    }
    public virtual void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            shootTimer = AttackSpeed;
            UpdateEnemy();
            if (CurrentEnemy != null)
            {
                Vector2 direction = CurrentEnemy.transform.position - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                ShootPosition = transform.GetChild(3).position;
                //transform.GetChild(3).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                Attack();
            }
            else
            {
                transform.rotation = Quaternion.identity;
                //transform.GetChild(3).rotation = Quaternion.identity;
            }
        }
    }

    public void ChangeSprite(int i)
    {
        throw new NotImplementedException();
    }

    public Sprite GetUpgradeSprite(int i)
    {
        throw new NotImplementedException();
    }
}