using UnityEngine;
using static ATower;

public class ArcherTowerFactory : AbstractFactoryTower
{
    [SerializeField]
    GameObject basicTowerPrefab;

    public override void CreateTower(Transform tower, Vector3 position, int placementIndex)
    {
        var towerGO = Instantiate(basicTowerPrefab, tower);
        towerGO.transform.position = position;
        towerGO.GetComponent<ArcherTower>().PlacementIndex = placementIndex;
        //tower.GetComponent<ArcherTower>().SetTower(id);
        //Debug.Log(PlayerStats.Money);//UI Design
    }
}
