using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class BlueDiamond : MonoBehaviour, IThrowable
{
    private Torus torus;

    private bool isLive = false;

    private float x, y, z;

    private void Awake()
    {
        torus = Torus.instance;
    }

    public void Throw()
    {
        isLive = true;

        x = Random.Range(-0.3f,0.3f);
        y = Random.Range(-0.3f, 1f);
        z = Random.Range(-0.3f, 0.3f);
        transform.position += new Vector3(x, y, z);

        torus.AddBlueDiamonds(transform);

        float lerpTimeX = Random.Range(0.03f,0.05f);
        float lerpTimeZ = Random.Range(0.01f,0.03f);

        torus.AddBlueDiamondLerpTime(lerpTimeX, lerpTimeZ);
        
    }

}
