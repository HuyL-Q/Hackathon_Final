using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeController : MonoBehaviour
{
    public static Text Attack;
    public static Text Health;
    public static Text AttackSpeed;
    public static Text Range;
    // Start is called before the first frame update
    //-->
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
    //delete if u see this class
    void Start()
    {
        Attack = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        Health = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Range = gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>();
        AttackSpeed = gameObject.transform.GetChild(3).GetChild(0).GetComponent<Text>();
    }

    public static void ChangeAttack(string amount)
    {
        Attack.text = amount;
    }
    public static void ChangeHealth(string amount)
    {
        Health.text = amount;
    }
    public static void ChangeRange(string amount)
    {
        Range.text = amount;
    }
    public static void ChangeAttackSpeed(string amount)
    {
        AttackSpeed.text = amount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
