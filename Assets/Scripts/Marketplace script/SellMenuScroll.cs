using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellMenuScroll : MonoBehaviour
{
    private GameObject Content;
    List<item> list;
    // Start is called before the first frame update
    async void Start()
    {
        Content = GameObject.Find("Sell Content");
        ApiConverter converter = new ApiConverter();
        converter.setId("hpiem-ue66e-gngde-xhede-3ntv2-mb6kq-jn5ud-6n7df-mbvpf-qqva7-xae");
        list = await converter.GetItem();
        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        yield return new WaitUntil(() => list != null);
        foreach(item item in list)
        {
            GameObject SellSlot = Instantiate((GameObject)Resources.Load("Prefabs/Sell Slot", typeof(GameObject)), Content.transform);
            GameObject prefab = (GameObject)Resources.Load(item.link, typeof(GameObject));
            SellSlot.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Image>().sprite = prefab.GetComponent<Image>().sprite;
            Button btn = SellSlot.transform.GetChild(0).GetComponent<Button>();
            btn.onClick.AddListener(delegate { SellMenuController.AddToShelf(btn); });
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
