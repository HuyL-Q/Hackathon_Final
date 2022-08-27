using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailScrollScript : MonoBehaviour
{
    private Transform content;
    private GameObject MailPrefab;
    public static MailScrollScript instance;
    int MailNumber;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        content = gameObject.transform.GetChild(0).GetChild(0);
        MailPrefab = (GameObject)Resources.Load("Prefabs/Mail Prefab", typeof(GameObject));
        MailNumber = 21;
        for (int i = 0; i < MailNumber; i++)
        {
            Instantiate(MailPrefab, content);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
