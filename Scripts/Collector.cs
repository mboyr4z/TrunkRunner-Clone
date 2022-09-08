using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoSingleton<Collector>
{
    [SerializeField] private float collectingTime;

    [SerializeField] private float destroyDistance;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ICollectable>()?.Collect(Collect);
    }

    private void Collect(Transform collectingObject)
    {
        gameManager.IncreaseDiamond();

        Actions.act_collectedDiamond?.Invoke();
    }

}