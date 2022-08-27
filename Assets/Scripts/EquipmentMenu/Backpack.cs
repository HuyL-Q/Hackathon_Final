using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class Backpack : MonoBehaviour
{
    public GameObject ItemPrefab;
    int i = 0;
    public static bool flagG = false;
    // Start is called before the first frame update
    async void Start()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitUntil(() => GameControllerE.flag);
        flagG = true;
        GameControllerE.DisableItem();
        foreach (Item item in GameControllerE.ItemList)
        {
            foreach(item data in datList.data)
            {
                if(item.Id == data.name)
                {
                    Transform Parent = GameObject.Find("Content").transform.GetChild(i);
                    ItemPrefab = (GameObject)Resources.Load(data.link, typeof(GameObject));
                    GameObject Item = Instantiate(ItemPrefab, Parent);
                    Item ItemScript = Item.GetComponent<Item>();
                    ItemScript.Id = item.Id;
                    ItemScript.Health = item.Health;
                    ItemScript.Attack = item.Attack;
                    ItemScript.Type = item.Type;
                    Item.name = item.Id;
                    Item.transform.position = Parent.GetChild(0).GetComponent<RectTransform>().position;
                    i++;
                }
            }
        }
        Champion chosen = GameControllerE.choosenHero;
        if(GameControllerE.equipmentSelectorList != null)
        foreach (EquipmentSelector eqc in GameControllerE.equipmentSelectorList)
        {
            if (chosen.ID == eqc.Id)
            {
                AutoEquip(chosen,eqc.Armor);
                AutoEquip(chosen,eqc.Boots);
                AutoEquip(chosen,eqc.Weapon);
                AutoEquip(chosen,eqc.Pants);
                AutoEquip(chosen,eqc.Helmet);
            }
        }
    }
    public class FinalStatConverter : JsonConverter<FinalStat> { }
    public void AutoEquip(Champion champ, string itemid)
    {
        FinalStatConverter fsc = new FinalStatConverter();
        fsc.setCurrentDir(@"\FinalStat.json");
        FinalStat fs = fsc.getObjectFromJSON();
        foreach (Item item in GameControllerE.ItemList)
        {
            if (itemid.Equals(item.Id))
            {
                foreach (item itm in datList.data)
                    if (item.Id == itm.name)
                    {
                        GameObject Item;
                        Item ItemScript;
                        switch (item.Type.ToString())
                        {
                            case "Helmet":
                                champ.Helmet = gameObject.AddComponent<Item>();
                                champ.Helmet.Id = item.Id;
                                champ.Helmet.Health = item.Health;
                                champ.Helmet.Attack = item.Attack;
                                champ.Helmet.Type = item.Type;
                                champ.Helmet.IsEquipped = true;
                                champ.Helmet.isAdded = true;
                                Item = GameObject.Find(item.Id);
                                ItemScript = Item.GetComponent<Item>();
                                Item.GetComponent<Image>().maskable = false;
                                ItemScript.Id = item.Id;
                                ItemScript.Health = item.Health;
                                ItemScript.Attack = item.Attack;
                                ItemScript.Type = item.Type;
                                Item.transform.SetParent(GameObject.Find("Helmet").transform);
                                Item.transform.position = GameObject.Find("Helmet").transform.GetComponent<RectTransform>().position;
                                champ.Health += item.Health;
                                champ.Damage += item.Attack;
                                break;
                            case "Pants":
                                champ.Pants = gameObject.AddComponent<Item>();
                                champ.Pants.Id = item.Id;
                                champ.Pants.Health = item.Health;
                                champ.Pants.Attack = item.Attack;
                                champ.Pants.Type = item.Type;
                                champ.Pants.IsEquipped = true;
                                champ.Pants.isAdded = true;
                                Item = GameObject.Find(item.Id);//
                                ItemScript = Item.GetComponent<Item>();
                                Item.GetComponent<Image>().maskable = false;//
                                ItemScript.Id = item.Id;
                                ItemScript.Health = item.Health;
                                ItemScript.Attack = item.Attack;
                                ItemScript.Type = item.Type;
                                Item.transform.SetParent(GameObject.Find("Pants").transform);//
                                Item.transform.position = GameObject.Find("Pants").transform.GetComponent<RectTransform>().position;
                                champ.Health += item.Health;
                                champ.Damage += item.Attack;
                                break;
                            case "Armor":
                                champ.Armor = gameObject.AddComponent<Item>();
                                champ.Armor.Id = item.Id;
                                champ.Armor.Health = item.Health;
                                champ.Armor.Attack = item.Attack;
                                champ.Armor.Type = item.Type;
                                champ.Armor.IsEquipped = true;
                                champ.Armor.isAdded = true;
                                Item = GameObject.Find(item.Id);//
                                ItemScript = Item.GetComponent<Item>();
                                Item.GetComponent<Image>().maskable = false;//
                                ItemScript.Id = item.Id;
                                ItemScript.Health = item.Health;
                                ItemScript.Attack = item.Attack;
                                ItemScript.Type = item.Type;
                                Item.transform.SetParent(GameObject.Find("Armor").transform);//
                                Item.transform.position = GameObject.Find("Armor").transform.GetComponent<RectTransform>().position;
                                champ.Health += item.Health;
                                champ.Damage += item.Attack;
                                break;
                            case "Boots":
                                champ.Boots = gameObject.AddComponent<Item>();
                                champ.Boots.Id = item.Id;
                                champ.Boots.Health = item.Health;
                                champ.Boots.Attack = item.Attack;
                                champ.Boots.Type = item.Type;
                                champ.Boots.IsEquipped = true;
                                champ.Boots.isAdded = true;
                                Item = GameObject.Find(item.Id);//
                                ItemScript = Item.GetComponent<Item>();
                                Item.GetComponent<Image>().maskable = false;//
                                ItemScript.Id = item.Id;
                                ItemScript.Health = item.Health;
                                ItemScript.Attack = item.Attack;
                                ItemScript.Type = item.Type;
                                Item.transform.SetParent(GameObject.Find("Boots").transform);//
                                Item.transform.position = GameObject.Find("Boots").transform.GetComponent<RectTransform>().position;
                                champ.Health += item.Health;
                                champ.Damage += item.Attack;
                                break;
                            case "Weapon":
                                champ.Weapon = gameObject.AddComponent<Item>();
                                champ.Weapon.Id = item.Id;
                                champ.Weapon.Health = item.Health;
                                champ.Weapon.Attack = item.Attack;
                                champ.Weapon.Type = item.Type;
                                champ.Weapon.IsEquipped = true;
                                champ.Weapon.isAdded = true;
                                Item = GameObject.Find(item.Id);//
                                ItemScript = Item.GetComponent<Item>();
                                Item.GetComponent<Image>().maskable = false;//
                                ItemScript.Id = item.Id;
                                ItemScript.Health = item.Health;
                                ItemScript.Attack = item.Attack;
                                ItemScript.Type = item.Type;
                                Item.transform.SetParent(GameObject.Find("Weapon").transform);//
                                Item.transform.position = GameObject.Find("Weapon").transform.GetComponent<RectTransform>().position;
                                champ.Health += item.Health;
                                champ.Damage += item.Attack;
                                break;
                        }
                    }

            }
        }
        AttributeController.ChangeAttack(fs.Attack.ToString());
        AttributeController.ChangeAttackSpeed(GameControllerE.championList[0].AttackSpeed.ToString());
        AttributeController.ChangeRange(GameControllerE.championList[0].Range.ToString());
        AttributeController.ChangeHealth(fs.Health.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
