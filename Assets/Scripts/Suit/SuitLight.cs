using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Experimental.Rendering.LWRP;

public class SuitLight : SuitStats
{
    public SuitStats suit;
    public bool isOn = true;
    public Light2D suitLight;
    public int lightLevel;

     void Start()
    {
        suitLight = GetComponent<Light2D>();
    }

    public void ToggleLight()
    {
        if (IsInvoking("ApplyPowerDrain"))
        {
            CancelInvoke("ApplyPowerDrain");
            powerDraining = false;
            Debug.Log("Invoke Cancelled (SuitLight)");
        }

        if (!isOn)
        {
            suitLight.intensity = Mathf.Lerp(1f, 0f, -0.01f);
            suit.powerDrain = suit.powerDrain + 1;
            isOn = true;
        }
        else
        {
            suitLight.intensity = Mathf.Lerp(0f, 1.0f, .01f);
            suit.powerDrain = suit.powerDrain - 1;
            isOn = false;
        }
    }

    private void Update()
    { 
        if(Input.GetKeyDown(KeyCode.L))
        {
            ToggleLight();
        }
    }
}
