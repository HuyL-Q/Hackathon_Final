using System.Collections.Generic;
using UnityEngine;
public interface ITower
{
    void ChangeSprite(int i);
    Sprite GetUpgradeSprite(int i);
    //void SetTower(string id);
    void Attack();
    int GetSize();
    int GetNextCost(string id);
    List<string> UpgradeTowerID(string id);
    void UpdateEnemy();
}

