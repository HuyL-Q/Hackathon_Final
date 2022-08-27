using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFactory : AbstractFactoryEnemy
{
    public override void createEnemy(string id)
    {
        string[] split = id.Split("_");
        GameObject minionsGameObject = ObjectPool.SharedInstance.GetPooledObject("Boss" + split[1]);
        if (minionsGameObject != null)
        {
            minionsGameObject.transform.position = SpawnController.Starts[Random.Range(0, 3)];
            minionsGameObject.transform.rotation = Quaternion.identity;
            minionsGameObject.SetActive(true);
            minionsGameObject.GetComponent<AEnemy>().SetEnemy(id);
        }
        else
        {
            throw new System.ArgumentException("Prefab does not exist.");
        }
    }
}