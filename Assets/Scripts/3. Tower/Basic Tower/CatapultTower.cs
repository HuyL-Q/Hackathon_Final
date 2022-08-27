using System.Collections.Generic;
using UnityEngine;

public class CatapultTower : ATower
{
    public class towerConverter : JsonConverter<List<towerJs>> { }
    public override void Start()
    {
        SpriteIndex = -1;
        towerConverter tc = new towerConverter();
        tc.setCurrentDir(@"\Assets\JSON\TowerStat.json");
        List<towerJs> towerList = tc.getObjectFromJSON();
        foreach (towerJs tower in towerList)
            if (tower.id.Contains("tower_catapult"))
            {
                IdList.Add(tower);
            }
        base.Start();
    }
    public override void SetTower(string id)
    {
        //import data from json here
        towerConverter tc = new towerConverter();
        tc.setCurrentDir(@"\Assets\JSON\TowerStat.json");
        List<towerJs> towerList = tc.getObjectFromJSON();
        foreach (towerJs tower in towerList)
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
    }
    public override int GetSize()
    {
        return Size;
    }
}
