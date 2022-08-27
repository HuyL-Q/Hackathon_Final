using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void MenuSwitch(MenuName menuName)
    {
        switch (menuName)
        {
            case MenuName.Gameplay:
                SceneManager.LoadScene("Gameplay");
                break;
            case MenuName.Main:
                SceneManager.LoadScene("Main Menu");
                break;
            case MenuName.Equipment:
                SceneManager.LoadScene("Equipment");
                break;
            case MenuName.Marketplace:
                SceneManager.LoadScene("Marketplace");
                break;
            case MenuName.Event:
                SceneManager.LoadScene("Event");
                break;
            case MenuName.Mail:
                SceneManager.LoadScene("Mail");
                break;
        }
    }
}
