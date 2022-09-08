using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoSingleton<CameraController>
{
    [SerializeField] private Transform target;

    [SerializeField] private float followingSensitivity = 0.1f;

    private GameManager gameManager;



    private Vector3 stackerOffset;


    private void Start()
    {
        gameManager = GameManager.instance;

        stackerOffset = target.position - transform.position;

    }

    private void FixedUpdate()
    {
        if(gameManager.GetState() == GameStates.InRun)
            FollowTarget();
    }


  
    private void FollowTarget()
    {
        transform.position = Vector3.Slerp(transform.position, target.position - stackerOffset, followingSensitivity);
    }

}
