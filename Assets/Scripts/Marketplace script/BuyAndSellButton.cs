using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyAndSellButton : MonoBehaviour
{
    public GameObject BuyMenu;
    public GameObject SellMenu;
    private GameObject currentMenu;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        currentMenu = BuyMenu;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeMenu()
    {
        if(currentMenu == BuyMenu)
        {
            currentMenu.SetActive(false);
            currentMenu = SellMenu;
            currentMenu.SetActive(true);
            text.text = "  Buy";
        }
        else
        {
            currentMenu.SetActive(false);
            currentMenu = BuyMenu;
            currentMenu.SetActive(true);
            text.text = "  Sell";
        }
    }
}
