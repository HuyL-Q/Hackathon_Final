using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellMenuController : MonoBehaviour
{
    public static GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        Image = gameObject.transform.GetChild(0).GetChild(0).gameObject;
    }

    public static void AddToShelf(Button btn)
    {
        Image.GetComponent<Image>().sprite = btn.transform.GetChild(0).GetComponent<Image>().sprite;
        var tempColor = Image.GetComponent<Image>().color;
        tempColor.a = 1f;
        Image.GetComponent<Image>().color = tempColor;
        
    }
    // Update is called once per frame
    void Update()
    {

    }
}
