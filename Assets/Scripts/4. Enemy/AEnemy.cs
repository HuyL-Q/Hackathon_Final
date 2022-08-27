using UnityEngine;
using UnityEngine.AI;

public abstract class AEnemy : MonoBehaviour, IEnemy
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Magnitude = "Magnitude";
    private const string Dead = "Dead";
    NavMeshAgent _agent;
    Animator _animator;
    GameObject _destination;
    //private int wavepointIndex;
    //string id;
    float _hp;
    //float runSpeed;
    int _damageToCastle;
    int _reward;
    //int size;
    //private bool dead;
    //public string Id { get => id; set => id = value; }
    public float HP { get => _hp; set => _hp = value; }
    public NavMeshAgent Agent { get => _agent; set => _agent = value; }
    public Animator Animator { get => _animator; set => _animator = value; }

    //public float RunSpeed { get => runSpeed; set => runSpeed = value; }
    public int DamageToCastle { get => _damageToCastle; set => _damageToCastle = value; }
    public int Reward { get => _reward; set => _reward = value; }
    //public int Size { get => size; set => size = value; }
    //public bool Dead { get => dead; set => dead = value; }
    //[Header("Unity Stuff")]
    //public Image HealthBar;
    //private double MaximumHealth;
    //Vector2 flag;
    //Vector3 target;

    //public virtual void AttackToCastle()
    //{
    //    PlayerStats.Lives -= DamageToCastle;
    //    PlayerStats.UpdateUI();
    //    Debug.Log(PlayerStats.Lives);
    //    ResetHealthBar();
    //    gameObject.SetActive(false);
    //    wavepointIndex = 0;

    //}
    //public virtual bool IsDead()
    //{
    //    return Dead;
    //}
    //public virtual void ResetHealthBar()
    //{
    //    HealthBar.fillAmount = 1;
    //}
    //public virtual void ReceiveDamage(float Damage)
    //{
    //    Hp -= Damage;
    //    HealthBar.fillAmount = (float)(Hp / MaximumHealth);
    //    if (Hp <= 0)
    //    {
    //        Reward(); //fix when add PlayerStat class
    //        Dead = true;
    //        SpawnController.EnemiesAlive--;
    //        gameObject.SetActive(false);
    //        ResetHealthBar();
    //        wavepointIndex = 0;
    //    }
    //}
    //public virtual void Reward()
    //{
    //    PlayerStats.Money += Reward;
    //    PlayerStats.Point += Mathf.Ceil(Reward * 1.5f);
    //    PlayerStats.UpdateUI();
    //}
    public virtual void Start()
    {
        Animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
        //MaximumHealth = Hp;
        //Dead = false;
    }

    public virtual void Update()
    {
        Animator.SetFloat(Magnitude, Agent.velocity.magnitude);
        Animator.SetFloat(Horizontal, Agent.velocity.x);
        Animator.SetFloat(Vertical, Agent.velocity.y);
        if (Agent.remainingDistance <= 1)
        {
            Agent.isStopped = true;
            AttackToCastle();
        }
        //if (Vector3.Distance(transform.position, SpawnController.Starts[0]) <= 0.2f && wavepointIndex == 0)
        //{
        //    target = SpawnController.wayPoint0[0];
        //    flag = transform.position;
        //}
        //if (Vector3.Distance(transform.position, SpawnController.Starts[1]) <= 0.2f && wavepointIndex == 0)
        //{
        //    target = SpawnController.wayPoint1[0];
        //    flag = transform.position;
        //}
        //if (Vector3.Distance(transform.position, SpawnController.Starts[2]) <= 0.2f && wavepointIndex == 0)
        //{
        //    target = SpawnController.wayPoint2[0];
        //    flag = transform.position;
        //}

        //Vector3 dir = target - transform.position;
        //transform.Translate(dir.normalized * RunSpeed * Time.deltaTime, Space.World);
        //if (Vector3.Distance(transform.position, target) <= 0.2f)
        //{
        //    if (Vector2.Distance(flag, SpawnController.Starts[0]) <= 0.2f)
        //    {
        //        GetNextWaypoint0();
        //    }
        //    if (Vector2.Distance(flag, SpawnController.Starts[1]) <= 0.2f)
        //    {
        //        GetNextWaypoint1();
        //    }
        //    if (Vector2.Distance(flag, SpawnController.Starts[2]) <= 0.2f)
        //    {
        //        GetNextWaypoint2();
        //    }
        //}
    }

    //void GetNextWaypoint0()
    //{
    //    if (wavepointIndex >= SpawnController.wayPoint0.Length - 1)
    //    {
    //        AttackToCastle();
    //        gameObject.SetActive(false);
    //        SpawnController.EnemiesAlive--;
    //        wavepointIndex = 0;
    //        return;
    //    }
    //    else
    //    {
    //        wavepointIndex++;
    //        target = SpawnController.wayPoint0[wavepointIndex];
    //    }
    //}

    //void GetNextWaypoint1()
    //{
    //    if (wavepointIndex >= SpawnController.wayPoint1.Length - 1)
    //    {
    //        AttackToCastle();
    //        gameObject.SetActive(false);
    //        SpawnController.EnemiesAlive--;
    //        wavepointIndex = 0;
    //        return;
    //    }
    //    else
    //    {
    //        wavepointIndex++;
    //        target = SpawnController.wayPoint1[wavepointIndex];
    //    }
    //}

    //void GetNextWaypoint2()
    //{
    //    if (wavepointIndex >= SpawnController.wayPoint2.Length - 1)
    //    {
    //        AttackToCastle();
    //        gameObject.SetActive(false);
    //        SpawnController.EnemiesAlive--;
    //        wavepointIndex = 0;
    //        return;
    //    }
    //    else
    //    {
    //        wavepointIndex++;
    //        target = SpawnController.wayPoint2[wavepointIndex];
    //    }
    //}

    public abstract void SetEnemy(string id);

    public void ReceiveDamage(float dmg)
    {
        //throw new System.NotImplementedException();
        HP -= dmg;
        if(HP < 0)
        {
            GiveReward();
            Animator.SetTrigger(Dead);
        }
    }

    public void AttackToCastle()
    {
        //throw new System.NotImplementedException();
        GameController.instance.PlayerLives -= DamageToCastle;
        StoryUIController.instance.UpdateLivesIndex();
        NewSpawnController.Instance.CurrentNumOfEnemies--;
        gameObject.SetActive(false);
    }

    public void GiveReward()
    {
        GameController.instance.PlayerMoney += Reward;
        GameController.instance.PlayerPoint += Mathf.Ceil(Reward * 1.5f);
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        NewSpawnController.Instance.CurrentNumOfEnemies--;
        gameObject.SetActive(false);    
    }

    private void OnEnable()
    {
        Agent = GetComponent<NavMeshAgent>();
        _destination = GameObject.Find("Destination");
        Agent.destination = _destination.transform.position;
    }
}
