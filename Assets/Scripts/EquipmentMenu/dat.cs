using System.Collections;
using System.Collections.Generic;
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
