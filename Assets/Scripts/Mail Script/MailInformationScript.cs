using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailInformationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static MailInformationScript instance;
    private Sprite GiftImage;
    private Text Mail;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        
    }

    public void AddGift(Item item)
    {
        GiftImage = item.ItemImage;
    }
    public void AddMail(string mail)
    {
        Mail.text = mail;
    }
    public void DeleteMail()
    {
        Destroy(gameObject.transform.parent);
    }
    public void CloseMail()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
