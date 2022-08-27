using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MScrollScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject pref = Resources.Load<GameObject>("Prefabs/Buy Slot");
        for (int i = 0; i < 10; i++)
        {
            Instantiate(pref, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
