using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public MenuTag tag;
    public bool open;

    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}

public enum MenuTag{
    Empty,
    LoseGamePanel,
    WinGamePanel,
    WaitPanel
}