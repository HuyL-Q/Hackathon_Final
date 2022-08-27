using UnityEngine;

public interface ITowerFactory
{
    void CreateTower(Transform tower, Vector3 position, int placementIndex);
}
