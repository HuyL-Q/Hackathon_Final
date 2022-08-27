using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollScript : MonoBehaviour
{
    private Transform Panel;
    private int SlotNumber;
    public int NumberOfItems = 0;
    private GameObject BackpackSlotPrefab;
    public static ScrollScript instance;

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
        BackpackSlotPrefab = (GameObject)Resources.Load("Prefabs/Backpack Slot", typeof(GameObject));
        Panel = gameObject.transform.GetChild(0).GetChild(0);
        SlotNumber = 21;
        NumberOfItems = 0;//Fix when done
        SlotExpand();
        for (int i = 0; i < SlotNumber; i++)
        {
            Instantiate(BackpackSlotPrefab, Panel);
        }
    }
    public void SlotExpand()
    {
        if (SlotNumber >= NumberOfItems)
            return;
        else
        {
            SlotNumber += 3;
            SlotExpand();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
