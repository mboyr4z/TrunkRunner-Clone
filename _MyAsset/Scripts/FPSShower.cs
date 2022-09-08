using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSShower : MonoBehaviour
{
    [SerializeField] private Text fpsText;

    float lastUpdate = -5;
    // Update is called once per frame

    private void Update()
    {
        if(Time.time - lastUpdate > 0.4f)
        {
            lastUpdate = Time.time;
            fpsText.text = ((int)(1f / Time.unscaledDeltaTime)).ToString();
        }
       
    }

}
