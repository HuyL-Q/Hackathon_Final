using UnityEngine;

public abstract class AbstractFactoryEnemy : MonoBehaviour, EnemyFactory
{
    public abstract void createEnemy(string id);
}
