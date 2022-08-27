using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : ATower
{
    List<int> priceToUpgrade;
    public class TowerConverter : JsonConverter<List<towerJs>> { }
    public override void Start()
    {
        SpriteIndex = -1;
        TowerConverter tc = new();
        tc.setCurrentDir(@"\Assets\JSON\TowerStat.json");
        List<towerJs> towerList = tc.getObjectFromJSON();
        foreach (towerJs tower in towerList)
            if (tower.id.Contains("tower_archer"))
            {
                IdList.Add(tower);
            }
        priceToUpgrade = new List<int>();
        SetTower("tower_archer_1");
        foreach (int price in priceToUpgrade)
        {
            Debug.Log(price);
        }
        base.Start();
    }
    public override void SetTower(string id)
    {
        priceToUpgrade.Clear();
        //import data from json here
        string[] idSplit = id.Split("_");
        string nextID = idSplit[0] + "_" + idSplit[1] + "_" + (int.Parse(idSplit[2]) + 1);
        TowerConverter tc = new();
        tc.setCurrentDir(@"\Assets\JSON\TowerStat.json");
        List<towerJs> towerList = tc.getObjectFromJSON();
        foreach (towerJs tower in towerList)
        {
            if (tower.id == id)
            {
                ID = tower.id;
                Damage = tower.attack;
                Range = tower.range;
                AttackSpeed = tower.attackSpeed;
                Price = tower.Cost;
                Size = tower.height;
                //Data = true;
            }
            if (tower.id.Contains(nextID))
            {
                priceToUpgrade.Add(tower.Cost);
            }
        }
    }
    public override int GetSize()
    {
        return Size;
    }
}
