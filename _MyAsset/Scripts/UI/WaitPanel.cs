using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaitPanel : MonoBehaviour
{
    private GameManager gameManager;

    private CanvasManager canvasManager;


    private void OnEnable()
    {
        gameManager = GameManager.instance;
        canvasManager = CanvasManager.instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameManager.SetState(GameStates.InRun);

            canvasManager.OpenMenu(MenuTag.Empty);
            
            Actions.act_gameStarted?.Invoke();
        }
    }
}
