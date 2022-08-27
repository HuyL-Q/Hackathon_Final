using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class datList : MonoBehaviour
{
    public static datList instance;
    public static List<item> data;
    public GameObject Loading;
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
    async void Start()
    {
        Debug.Log("datList loading...");
        ApiConverter conv = new ApiConverter();
        conv.setId("hpiem-ue66e-gngde-xhede-3ntv2-mb6kq-jn5ud-6n7df-mbvpf-qqva7-xae");
        data = await conv.GetItem();
        foreach (item item in data)
        {
            Debug.Log(item.link + " " + item.name);
        }
        while (true)
        {
            if (data != null)
            {
                Loading.SetActive(false);
                break;
            }
        }
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
