using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour, ICollectable, IThrowable
{
    [SerializeField] private float collectTime;

    [SerializeField] private float destroyDistance;

    private GameManager gameManager;


    private bool isCollect = false;

    private bool isThrow = false;

    private void Start()
    {
        gameManager = GameManager.instance;
    }



    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IObstackle>()?.Hit(DoSomethingByObstackleType, ObjectType.Diamond);
    }

    private void DoSomethingByObstackleType(Transform obstackleTransform, ObjectType obstackleType)
    {
        if (obstackleType == ObjectType.Cube)
            DestroyObject();
    }

    public void Collect(Action<Transform> act)
    {
        if (!isCollect && !isThrow)
        {
            isCollect = true;
            gameManager.IncreaseDiamond();

            act.Invoke(transform);
            Actions.act_collectedDiamond?.Invoke();
        }
    }

    public void Throw()
    {
        isThrow = true;
    }

   

    private void DestroyObject()
    {
       Destroy(gameObject);
    }
}
