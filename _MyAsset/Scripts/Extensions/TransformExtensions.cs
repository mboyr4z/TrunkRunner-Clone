using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{


    public static void XClamp(this Transform tr, float x1, float x2)
    {
        tr.position = new Vector3(Mathf.Clamp(tr.position.x, x1, x2), tr.position.y, tr.position.z);
    }



    public static void YClamp(this Transform tr, float y1, float y2)
    {
        tr.position = new Vector3(tr.position.x, Mathf.Clamp(tr.position.y, y1, y2), tr.position.z);
    }

    public static void ZClamp(this Transform tr, float z1, float z2)
    {
        tr.position = new Vector3(tr.position.x, tr.position.y, Mathf.Clamp(tr.position.z, z1, z2));
    }
}

