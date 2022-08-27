using UnityEngine;

public class HeroTowerFactory : AbstractFactoryTower
{
    public override void CreateTower(Transform tower, Vector3 position, int placementIndex)
    {
        GameObject heroTowerPrefab = Resources.Load("Prefabs/HeroTower") as GameObject;
        if (heroTowerPrefab != null)
        {
            Instantiate(heroTowerPrefab);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not existed.");
        }
    }
}
