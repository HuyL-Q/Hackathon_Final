using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Scrollbar Scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(loading());
        Scrollbar.size = 1;
    }
    IEnumerator loading()
    {
        Scrollbar.size = 0;
        while (true)
        {
            if (Scrollbar.size < 0.8f)
                Scrollbar.size += 0.00000000000000000000000000000000005f;
            Debug.Log("S");
            yield return new WaitUntil(()=>GameControllerE.datList != null);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
