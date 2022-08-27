using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnd : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void GoToMain()
    {
        Time.timeScale = 1;
        MenuManager.MenuSwitch(MenuName.Main);
    }
}
