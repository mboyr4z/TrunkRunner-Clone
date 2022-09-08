using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class Cube : MonoBehaviour, IObstackle
{
    private ObjectPoolManager objectPoolManager;

    private ObjectType objectType = ObjectType.Cube;

    private void Start()
    {
        objectPoolManager = ObjectPoolManager.instance;
    }
    public void Hit(Action<Transform, ObjectType> act, ObjectType objectType)
    {
        act.Invoke(transform, this.objectType);
        
        if (objectType == ObjectType.Diamond) {     // spawn blue diamonds 4 times

            int againt = Random.Range(1, 4);

            for (int i = 0; i < againt; i++)
            {
                GameObject blueDiamond = objectPoolManager.SpawnFromPool(PoolingObjectsTag.blueDiamond, transform.position, Quaternion.identity);
                blueDiamond.GetComponent<IThrowable>()?.Throw();
            }
            Destroy(gameObject);    
        }

    }
}
