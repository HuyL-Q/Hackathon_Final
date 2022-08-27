using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class dat
{
    public List<item> Data;
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
    public Link(string owner, List<string> link, float balance)
    {
        this.owner = owner;
        this.link = link;
        this.balance = balance;
    }
    public async Task<Link> getLinkFromAPIAsync(string link)//use this as constructor
    {
        ApiConverter ac = new ApiConverter();
        Link linkFromAPI = await ac.GetLinkList(link);
        return linkFromAPI;
    }
    public async Task<List<item>> GetItemFromLinkAsync()//return list item
    {
        List<item> itemList = new List<item>();
        ApiConverter ac = new ApiConverter();
        foreach(string link in link)
        {
            itemList.Add(await ac.GetItemChoosen(link));
        }
        return itemList;
    }
}