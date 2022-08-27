using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    //bool IsDead();
    void ReceiveDamage(float damage);
    void AttackToCastle();
    void GiveReward();
    //void SetEnemy(string id);
}