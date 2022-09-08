using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour, IObstackle
{

    private ObjectType objectType = ObjectType.FinishLine;
    public void Hit(Action<Transform, ObjectType> act, ObjectType objectType)
    {
        act.Invoke(transform, this.objectType);
    }
}
