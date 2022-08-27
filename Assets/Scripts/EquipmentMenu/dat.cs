using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dat
{
    public List<item> Data;
    public List<Link> Link;
    public List<item> AddItemToList()
    {

        return Data;
    }
}
public class item
{
    public string name;
    public string link;

    public item(string name, string link)
    {
        this.name = name;
        this.link = link;
    }
}
public class Link
{
    public string owner;
    public List<string> link;
    public float balance;
    public Link() { }
    public Link(string link)
    {
        
    }
}