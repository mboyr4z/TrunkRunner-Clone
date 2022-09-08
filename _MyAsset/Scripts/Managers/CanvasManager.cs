using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoSingleton<CanvasManager>
{

    [SerializeField] private Menu[] menus;

    public void OpenMenu(MenuTag menuTag)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].tag == menuTag)
            {
                menus[i].Open();
            }
            else if (menus[i].open)
            {
                CloseMenu(menus[i]);
            }
        }
    }

    public void CloseMenu(MenuTag menuTag)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].tag == menuTag)
            {
                menus[i].Close();
                break;
            }      
        }
    }

    public void OpenMenu(Menu menu)
    {
        menu.Open();
    }

    public void CloseMenu(Menu menu)
    {
        menu.Close();
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
