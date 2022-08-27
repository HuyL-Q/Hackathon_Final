using System;
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
    private string id;
    private int damage;
    private float range;
    private double attackSpeed;
    private int price;
    private int size;
    private List<String> special;
    private Vector3 shootPosition;
    private GameObject currentEnemy;
    public ObjectPool<GameObject> objectPool;
    private double shootTimer;
    private int spriteIndex;
    List<towerJs> idList = new List<towerJs>();
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
    public List<towerJs> IdList { get => idList; set => idList = value; }
    public int PlacementIndex { get => placementIndex; set => placementIndex = value; }

    public class towerJs
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
        public towerJs(string id, int attack, double attackSpeed, float range, List<string> special, int cost, int width, int height, string bulletID)
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
    public abstract void SetTower(string id);
    public virtual void Attack()
    {
        GameObject arrowGO = objectPool.Get();
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
        foreach (towerJs i in IdList)
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
        foreach (towerJs i in IdList)
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

    }

    public virtual void UpdateEnemy()
    {
        List<GameObject> enemies = new(GameObject.FindGameObjectsWithTag("Minions"));
        //enemies.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("Boss")));
        float distance = Mathf.Infinity;
        GameObject targetEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = (transform.position - enemy.transform.position).magnitude;
            if (enemyDistance < distance)
            {
                targetEnemy = enemy;
                distance = enemyDistance;
            }
        }
        if (distance <= Range)
        {
            CurrentEnemy = targetEnemy;
        }
        else
        {
            CurrentEnemy = null;
        }
    }
    public virtual void Start()
    {
        ShootPosition = transform.Find("ShootFromPos").position;
        shootTimer = AttackSpeed;
        objectPool = new ObjectPool<GameObject>(() => { return Instantiate(bullet); }
                                                , obj => { obj.gameObject.SetActive(true); }
                                                , obj => { obj.gameObject.SetActive(false); }
                                                , obj => { Destroy(obj.gameObject); }
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
                Attack();
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
