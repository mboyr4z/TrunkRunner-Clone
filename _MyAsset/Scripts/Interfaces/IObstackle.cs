using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstackle
{
    public void Hit(Action<Transform, ObjectType> act, ObjectType objectType);
}
