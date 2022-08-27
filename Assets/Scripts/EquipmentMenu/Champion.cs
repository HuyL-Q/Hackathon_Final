using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Champion : ATower
{
    public bool Disable;
    private int health;
    public Item Helmet;
    public Item Pants;
    public Item Armor;
    public Item Boots;
    public Item Weapon;
    public List<string> Items = new List<string>();
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public Champion(string id, int damage, int health, float range, double attackSpeed, int price, bool status)
    {
        this.ID = id;
        this.Damage = damage;
        this.health = health;
        this.Range = range;
        this.AttackSpeed = attackSpeed;
        this.Price = price;
        this.Disable = status;
    }
    IEnumerator wait2()
    {
        yield return new WaitUntil(() => GameControllerE.flag);
    }
    public void setChampion(string id)// ?
    {
        StartCoroutine(wait2());
        foreach(Champion champion in GameControllerE.championList)
        {
            if(champion.ID == id)
            {
                this.ID = champion.ID;
                this.Health = champion.Health;
                this.Damage = champion.Damage;
                this.Range = champion.Range;
                this.AttackSpeed = champion.AttackSpeed;
                this.Price = champion.Price;
                this.Disable = champion.Disable;
                GameControllerE.choosenHero = this;
            }
        }
        if(GameControllerE.equipmentSelectorList != null)
        foreach (EquipmentSelector eqc in GameControllerE.equipmentSelectorList)
        {
                if (this.ID == eqc.Id)
                {
                    Items.Add(eqc.Armor);
                    Items.Add(eqc.Boots);
                    Items.Add(eqc.Weapon);
                    Items.Add(eqc.Pants);
                    Items.Add(eqc.Helmet);
                    break;
                }
            }
    }
    // Start is called before the first frame update
    public override void Start()
    {
        //implement champion image here
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitUntil(() => GameControllerE.datList != null);
        setChampion("tower_hero_01");
    }
    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log(this.Helmet + " " + this.Pants + " " + this.Armor + " " + this.Boots + " " + this.Weapon);
    }
    public void saveChampion()
    {
        int index = int.Parse(ID.Substring(ID.Length-2))-1;
        GameControllerE.championList[index] = this;
    }


    public void removeItem(string type)
    {
        switch (type)
        {
            case "Helmet":
                this.Helmet = null;
                break;
            case "Pants":
                this.Pants = null;
                break;
            case "Armor":
                this.Armor = null;
                break;
            case "Boots":
                this.Boots = null;
                break;
            case "Weapon":
                this.Weapon = null;
                break;
        }
        Destroy(GameObject.Find(type).transform.GetChild(1).gameObject);
    }
    public override void SetTower(string id)
    {
        throw new System.NotImplementedException();
    }

    public override int GetSize()
    {
        throw new System.NotImplementedException();
    }
}
