using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerE : MonoBehaviour
{
    public static List<Champion> championList;
    public static List<Item> ItemList;
    public static List<item> datList;
    public static List<EquipmentSelector> equipmentSelectorList;
    public GameObject changeHeroMenu;
    public static GameObject ChangeHeroMenu;
    public static Champion choosenHero;
    public class championJson
    {
        public string id;
        public int damage;
        public int health;
        public float range;
        public double attackSpeed;
        public int price;
        public bool status;
    }
    public class ItemJs
    {
        public string id;
        public int health;
        public string type;
        public int attack;
    }
    public class EquipmentSelectorConverter : JsonConverter<List<EquipmentSelector>> { }
    public class FinalStatConverter : JsonConverter<FinalStat> { }
    public class itemConverter: JsonConverter<List<ItemJs>> { }
    public class championConverter : JsonConverter<List<championJson>> { }
    public static RaycastHit2D hit;
    public GameObject ChampionImage;
    public class ObjConverter : JsonConverter<List<Champion>> { };
    // Start is called before the first frame update
    public static bool flag;
    async void Start()
    {
        flag = false;
        ApiConverter converter = new ApiConverter();
        converter.setId("hpiem-ue66e-gngde-xhede-3ntv2-mb6kq-jn5ud-6n7df-mbvpf-qqva7-xae");
        datList = await converter.GetItem();
        StartCoroutine(wait());
        ChangeHeroMenu = changeHeroMenu;
        championList = new List<Champion>();
        ItemList = new List<Item>();
        equipmentSelectorList = new List<EquipmentSelector>();
        resetChampList();
        resetEquipmentList();
        ResetSelector();
        ChampionImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Prefabs/Champion/" + championList[0].ID);
    }
    IEnumerator wait()
    {
        yield return new WaitUntil(() => GameControllerE.datList != null);
        flag = true;
    }
    public static void EnableChangeHeroMenu()
    {
        ChangeHeroMenu.SetActive(true);
    }
    public void SaveHeroData()
    {
        Champion champion = choosenHero;
        List<EquipmentSelector> list = new List<EquipmentSelector>();
        EquipmentSelector eqc = new EquipmentSelector();
        eqc.Id = champion.ID;
        if (champion.Helmet != null)
        {
            Debug.Log("Check");
            eqc.Helmet = champion.Helmet.Id;
        }
        if (champion.Pants != null)
        {
            eqc.Pants = champion.Pants.Id;
        }
        if (champion.Armor != null)
        {
            eqc.Armor = champion.Armor.Id;
        }
        if (champion.Boots != null)
        {
            eqc.Boots = champion.Boots.Id;
        }
        if (champion.Weapon != null)
        {
            eqc.Weapon = champion.Weapon.Id;
        }
        list.Add(eqc);
        EquipmentSelectorConverter esc = new EquipmentSelectorConverter();
        esc.setCurrentDir(@"\EquipmentSelector.json");
        esc.createJSON(list);
        FinalStatConverter fsc = new FinalStatConverter();
        FinalStat fs = new FinalStat(int.Parse(GameObject.Find("Attack").transform.GetChild(0).gameObject.GetComponent<Text>().text), int.Parse(GameObject.Find("Health").transform.GetChild(0).gameObject.GetComponent<Text>().text));
        fsc.setCurrentDir(@"\FinalStat.json");
        fsc.createJSON(fs);
    }
    public void ResetSelector()
    {
        equipmentSelectorList.Clear();
        EquipmentSelectorConverter eqc = new EquipmentSelectorConverter();
        eqc.setCurrentDir(@"\EquipmentSelector.json");
        equipmentSelectorList = eqc.getObjectFromJSON();
        //auto equip
    }
    public static void DisableChangeHeroMenu()
    {
        ChangeHeroMenu.SetActive(false);
    }
    public static void resetChampList()
    {
        championList.Clear();
        championConverter cc = new championConverter();
        cc.setCurrentDir(@"\champion.json");
        List<championJson> championJsons = cc.getObjectFromJSON();
        foreach (championJson championJson in championJsons)
        {
            Champion champ = new Champion(championJson.id, championJson.damage,championJson.health, championJson.range, championJson.attackSpeed, championJson.price, championJson.status);
            championList.Add(champ);
        }
    }
    public static void DisableItem()
    {
        List<Item> removeItem = new List<Item>();
        foreach (Item item in ItemList)
        {
            foreach (item item1 in datList)
            {
                if (item.Id == item1.name)
                {
                    removeItem.Add(item);
                }
            }
        }
        ItemList = removeItem;
    }
    public static void resetEquipmentList()
    {
        ItemList.Clear();
        itemConverter c = new itemConverter();
        c.setCurrentDir(@"\Equipment.json");
        List<ItemJs> ItemJsons = c.getObjectFromJSON();
        foreach (ItemJs I in ItemJsons)
        {
            Item champ = new Item(I.id, I.health, I.attack, I.type);
            ItemList.Add(champ);
        }
    }
    // Update is called once per frame
    void Update()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity);
    }
}
