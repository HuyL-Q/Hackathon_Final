using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    private Item item;
    private string mailData = " ";
    // Start is called before the first frame update
    public GameObject MailInformation;

    public Item Item { get => item; set => item = value; }
    public string MailData { get => mailData; set => mailData = value; }

    void Start()
    {
        MailInformation = GameObject.Find("Canvas");
        MailInformation = MailInformation.transform.GetChild(4).gameObject;
    }

    public void OpenMail()
    {
        MailInformation.SetActive(true);
        MailInformationScript MailInfo = MailInformation.GetComponent<MailInformationScript>();
        //MailInfo.AddMail(MailData);
        //if(item != null)
        //    MailInfo.AddGift(item);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
