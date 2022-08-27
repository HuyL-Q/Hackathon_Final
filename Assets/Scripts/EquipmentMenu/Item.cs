using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Type
{
    Helmet, Pants, Armor, Boots, Weapon, n
}
public class Item : MonoBehaviour
{
    private string id;
    private int health;
    private int attack;
    private Type type;
    private bool isEquipped;
    public bool isAdded;
    public Sprite ItemImage;

    public string Id { get { return id; } set { id = value; } }
    public int Attack { get { return attack; } set { attack = value; } }
    public int Health { get { return health; } set { health = value; } }
    public Type Type { get { return type; } set { type = value; } }
    public bool IsEquipped { get { return isEquipped; } set { isEquipped = value; } }
    public Item() { }
    public Item(int health, int attack)
    {
        Health = health;
        Attack = attack;
    }
    public Item(string id, int health, int attack, string type)
    {
        Id = id;
        Health = health;
        Attack = attack;
        Type type1 = Type.n;
        if (Type.TryParse(type, out type1)) Type = type1;
    }
    public void setItem(string id, int health, int attack, Type typez)
    {
        Id = id;
        Health = health;
        Attack = attack;
        type = typez;
    }

    // Start is called before the first frame update
    void Start()
    {
        isAdded = false;
    }

    // Update is called once per frame
    void Update()
    {
        ItemImage = gameObject.GetComponent<Image>().sprite;
    }
}
