using UnityEngine;

public abstract class AbstractFactoryTower : MonoBehaviour, ITowerFactory
{
    public abstract void CreateTower(Transform tower, Vector3 position, int placementIndex);
}