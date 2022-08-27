using UnityEngine;

public class CatapultTowerFactory : AbstractFactoryTower
{
    public override void CreateTower(Transform tower, Vector3 position, int placementIndex)
    {
        GameObject basicTowerPrefab = Resources.Load("Prefabs/Tower/CatapultTower") as GameObject;
        if (basicTowerPrefab != null)
        {
            var towerGO = Instantiate(basicTowerPrefab);
            //tower.GetComponent<CatapultTower>().SetTower(id);
            //PlayerStats.Money -= tower.GetComponent<CatapultTower>().Price;
            //Debug.Log(PlayerStats.Money);//UI Design
        }
        else
        {
            throw new System.ArgumentException("Prefab does not existed.");
        }
    }
}
