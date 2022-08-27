using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ArcherTower : ATower
{
    List<int> priceToUpgrade;

    public List<int> PriceToUpgrade { get => priceToUpgrade; }

    public class TowerConverter : JsonConverter<List<TowerJs>> { }
    public override void Start()
    {
        //SpriteIndex = -1;
        //TowerConverter tc = new();
        //tc.SetCurrentDir(@"\TowerStat.json");
        //List<TowerJs> towerList = tc.GetObjectFromJSON();
        //foreach (TowerJs tower in towerList)
        //    if (tower.id.Contains("tower_archer"))
        //    {
        //        IdList.Add(tower);
        //    }
        priceToUpgrade = new List<int>();
        StartCoroutine(SetTower("tower_archer_1"));
        //foreach (int price in priceToUpgrade)
        //{
        //    Debug.Log(price);
        //}
        base.Start();
    }
    public override IEnumerator SetTower(string id)
    {
        PriceToUpgrade.Clear();
        //import data from json here
        string[] idSplit = id.Split("_");
        string nextID = idSplit[0] + "_" + idSplit[1] + "_" + (int.Parse(idSplit[2]) + 1);
        TowerConverter tc = new TowerConverter();
        tc.setCurrentDir(@"\TowerStat.json");
        UnityWebRequest uwr = UnityWebRequest.Get(tc.CurrentDirectory);
        yield return uwr.SendWebRequest();
        List<TowerJs> towerList = tc.getObjectfromText(uwr.downloadHandler.text);
        foreach (TowerJs tower in towerList)
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
                PriceToUpgrade.Add(tower.Cost);
            }
        }
        transform.GetChild(2).localScale = new Vector2(Range, Range);
    }
    public override int GetSize()
    {
        return Size;
    }
}