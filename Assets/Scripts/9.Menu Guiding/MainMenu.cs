using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        MenuManager.MenuSwitch(MenuName.Gameplay);
    }
    public void Equipment()
    {
        MenuManager.MenuSwitch(MenuName.Equipment);
    }
    public void Marketplace()
    {
        MenuManager.MenuSwitch(MenuName.Marketplace);
    }
    public void Main()
    {
        MenuManager.MenuSwitch(MenuName.Main);
    }    
}
