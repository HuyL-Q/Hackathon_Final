using System;
using UnityEngine;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour
{
    private RaycastHit2D hit;
    private Vector3 oldPos;
    private Transform oldTransform;
    private ScrollRect ScrollRect;
    private Color temp;
    private string type;
    private string from;
    private string to;
    void Start()
    {
        hit = GameControllerE.hit;
        ScrollRect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        type = gameObject.GetComponent<Item>().Type.ToString();
    }
    public void OnMouseDown()
    {
        from = null;
        to = null;
        oldPos = gameObject.transform.position;
        ScrollRect.vertical = false;
        temp = gameObject.GetComponent<Image>().color;
        temp.a = 0.6f;
        Item item = gameObject.GetComponent<Item>();
        gameObject.GetComponent<Image>().color = temp;
        oldTransform = gameObject.transform.parent;
        gameObject.transform.SetParent(GameObject.Find("Canvas").transform);
        gameObject.transform.SetAsLastSibling();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnMouseDrag()
    {
        try
        {
            if (from == null)
                from = hit.collider.tag;
        }
        catch (Exception E)
        {
            from = null;
            Debug.Log(E);
        }
        gameObject.transform.position = Vector2.Lerp(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
        gameObject.GetComponent<Image>().maskable = false;
    }
    public void OnMouseUp()
    {
        try
        {
            if (to == null)
                to = hit.collider.tag;
        }
        catch (Exception E)
        {
            to = null;
            Debug.Log(E);
        }
        ScrollRect.vertical = true;
        temp.a = 1f;
        gameObject.GetComponent<Image>().color = temp;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Equipment Slot") && type == hit.collider.gameObject.GetComponent<ItemSlot>().type || hit.collider.CompareTag("Backpack Slot"))
            {//drop in slot
                gameObject.transform.position = hit.collider.gameObject.transform.position;
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                gameObject.transform.SetParent(hit.collider.gameObject.transform);
                if(gameObject.transform.parent.name.Contains("Backpack Slot"))
                {//drop in backpack slot
                    gameObject.GetComponent<Image>().maskable = true;
                    gameObject.GetComponent<Item>().IsEquipped = false;
                    switch (gameObject.GetComponent<Item>().Type.ToString())
                    {
                        case "Helmet":
                            GameControllerE.choosenHero.Helmet = null;
                            break;
                        case "Pants":
                            GameControllerE.choosenHero.Pants = null;
                            break;
                        case "Armor":
                            GameControllerE.choosenHero.Armor = null;
                            break;
                        case "Boots":
                            GameControllerE.choosenHero.Boots = null;
                            break;
                        case "Weapon":
                            GameControllerE.choosenHero.Weapon = null;
                            break;
                    }
                    if (from != to)
                    {
                        GameControllerE.choosenHero.Health -= gameObject.GetComponent<Item>().Health;
                        GameControllerE.choosenHero.Damage -= gameObject.GetComponent<Item>().Attack;
                    }
                    AttributeController.ChangeAttack(GameControllerE.choosenHero.Damage.ToString());
                    AttributeController.ChangeHealth(GameControllerE.choosenHero.Health.ToString());
                }
                else
                {//drop miss backpack slot
                    switch (gameObject.GetComponent<Item>().Type.ToString())
                    {
                        case "Helmet":
                            GameControllerE.choosenHero.Helmet = gameObject.GetComponent<Item>();
                            GameControllerE.choosenHero.Helmet.IsEquipped = true;
                            break;
                        case "Pants":
                            GameControllerE.choosenHero.Pants = gameObject.GetComponent<Item>();
                            GameControllerE.choosenHero.Pants.IsEquipped = true;
                            break;
                        case "Armor":
                            GameControllerE.choosenHero.Armor = gameObject.GetComponent<Item>();
                            GameControllerE.choosenHero.Armor.IsEquipped = true;
                            break;
                        case "Boots":
                            GameControllerE.choosenHero.Boots = gameObject.GetComponent<Item>();
                            GameControllerE.choosenHero.Boots.IsEquipped = true;
                            break;
                        case "Weapon":
                            GameControllerE.choosenHero.Weapon = gameObject.GetComponent<Item>();
                            GameControllerE.choosenHero.Weapon.IsEquipped = true;
                            break;
                    }
                    if(from != to)
                    {
                        GameControllerE.choosenHero.Health += gameObject.GetComponent<Item>().Health;
                        GameControllerE.choosenHero.Damage += gameObject.GetComponent<Item>().Attack;
                    }
                    AttributeController.ChangeAttack(GameControllerE.choosenHero.Damage.ToString());
                    AttributeController.ChangeHealth(GameControllerE.choosenHero.Health.ToString());
                }
            }
            else
            {//drop miss slot
                gameObject.transform.SetParent(oldTransform);
                gameObject.transform.position = oldPos;
            }
        }
        else
        {
            gameObject.transform.SetParent(oldTransform);
            gameObject.transform.position = oldPos;
        }
    }

    private void Update()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero, Mathf.Infinity);
    }
}
