using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSelector
{
    private string id = "";
    private string helmet = "";
    private string pants = "";
    private string armor = "";
    private string boots = "";
    private string weapon = "";

    public string Id { get => id; set => id = value; }
    public string Helmet { get => helmet; set => helmet = value; }
    public string Pants { get => pants; set => pants = value; }
    public string Armor { get => armor; set => armor = value; }
    public string Boots { get => boots; set => boots = value; }
    public string Weapon { get => weapon; set => weapon = value; }

    public EquipmentSelector() { }
    public EquipmentSelector(string id, string helmet, string pants, string armor, string boots, string weapon)
    {
        this.id = id;
        this.helmet = helmet;
        this.pants = pants;
        this.armor = armor;
        this.boots = boots;
        this.weapon = weapon;
    }
    public string ToStrin()
    {
        return this.id + " " + this.helmet + " " + this.pants + " " + this.armor + " " + this.boots + " " + this.weapon;
    }
}
