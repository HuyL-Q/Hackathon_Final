using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool isEquipped = false;
    private Color c;
    public Item equippedItem;
    public string type;
    public void IsEquipped(bool b)
    {
        isEquipped = b;
    }
    public bool IsEquipped() { return isEquipped; }
    // Start is called before the first frame update
    void Start()
    {
        c = gameObject.transform.GetChild(0).GetComponent<Image>().color;
        type = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.childCount == 2)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            IsEquipped(true);
            equippedItem = gameObject.transform.GetChild(1).GetComponent<Item>();
        }
        else
        {
            IsEquipped(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (isEquipped)
        {
            //Debug.Log(GameController.choosenHero.ID);
            gameObject.transform.GetChild(0).GetComponent<Image>().color = Color.black;
        }
        else
            gameObject.transform.GetChild(0).GetComponent<Image>().color = c;
    }
}
