using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SamuraiBoss : MonoBehaviour
{
    int hp;
    int maxHp;
    int atkDamage;

    //float time;
    public delegate void onHealthChange();
    public event onHealthChange OnHealthChange;
    Animator _animator;

    public int Hp
    {
        get => hp; set
        {
            if (hp == value) return;
            hp = value;
            OnHealthChange?.Invoke();
        }
    }
    public int AtkDamage { get => atkDamage; set => atkDamage = value; }
    public int MaxHp { get => maxHp; set => maxHp = value; }

    // Start is called before the first frame update
    void Start()
    {
        //time = 1;
        _animator = GetComponent<Animator>();
        StartCoroutine(RunTowardsPosition());
        SetStatus();
        OnHealthChange += ReceiveDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (EventController.Instance.State == State.Start)
        {
            _animator.SetInteger("State", (int)State.Start);
            GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
            foreach(GameObject hero in heroes)
            {
                if(hero.GetComponent<Heroes>().HP > 0)
                {
                    _animator.SetBool("hasHero", true);
                    break;
                }
                _animator.SetBool("hasHero", false);
            }
            //if (time <= 0)
            //{
            //    Hp -= 1;
            //    time = 1;
            //    Debug.Log(Hp);
            //}
            //time -= Time.deltaTime;
            if(Hp <= 0)
            {
                _animator.SetTrigger("Dead");
                EventController.Instance.State = State.End_Victory;
            }
        }
    }
    IEnumerator RunTowardsPosition()
    {
        gameObject.transform.DOMove(EventController.Instance.spawnPosition.transform.position, 3).SetEase(Ease.Linear);
        yield return new WaitForSeconds(3f);
        _animator.SetBool("arrivedAtPos", true);
    }

    void SetStatus()
    {
        MaxHp = 1000;
        Hp = MaxHp;
        AtkDamage = 50;
    }

    void ReceiveDamage()
    {
        EventUIController.instance.SetValueHealthBar((float)Hp / MaxHp);
    }

    public void Attack()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        foreach(GameObject hero in heroes)
        {
            hero.GetComponent<Heroes>().ReceiveDamage(AtkDamage);
        }
    }

    public void AfterDeath()
    {
        Destroy(gameObject);
    }
}
