using System.Collections.Generic;
using UnityEngine;

public class HeroTower : ATower
{
    public override void Attack()
    {
        base.Attack();
        //throw new System.NotImplementedException();
        //add when got bullet
    }
    public override int GetSize()
    {
        return Size;
    }
    public override void UpdateEnemy()
    {
        CurrentEnemy = GameObject.FindGameObjectWithTag("Boss");
        //base.UpdateEnemy();
    }
    public override void Start()
    {
        SetStatus();
        base.Start();
    }
    public void SetStatus()
    {
        AttackSpeed = 1;
        Damage = 10;
    }
    public override List<string> UpgradeTowerID(string id)
    {
        throw new System.NotImplementedException();
    }
    public override void SetTower(string id)
    {
        throw new System.NotImplementedException();
    }
    public override int GetNextCost(string id)
    {
        throw new System.NotImplementedException();
    }
}
