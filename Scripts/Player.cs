using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Player : MonoBehaviour
{

    private GameManager gameManager;

    private CanvasManager canvasManager;

    private Rigidbody rb;

    private Collider collider;



    private void Start()
    {
        gameManager = GameManager.instance;
        canvasManager = CanvasManager.instance;
        
        collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }


  
    


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IObstackle>()?.Hit(DoSomethingByObstackleType, ObjectType.Player);
    }

    private void DoSomethingByObstackleType(Transform obstackleTransform, ObjectType obstackleType)
    {
        if (obstackleType == ObjectType.Cube)
            Death();

        if (obstackleType == ObjectType.FinishLine)
            Win();
    }

    private void Win()
    {
        gameManager.IncreaseLevel();
        gameManager.SetState(GameStates.InWinPanel);
        canvasManager.OpenMenu(MenuTag.WinGamePanel);
        rb.velocity = Vector3.zero;
        transform.DOLocalRotate(new Vector3(0, 180, 0), 0.5f).OnComplete(() => { Actions.act_winLevel?.Invoke(); }) ;
    }

    private void Death()
    {
        gameManager.SetState(GameStates.InLosePanel);
        canvasManager.OpenMenu(MenuTag.LoseGamePanel);
        rb.velocity = Vector3.zero;
        collider.enabled = false;
        Destroy(rb);
        Actions.act_loseLevel?.Invoke();
    }

}

