using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLightManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Light[] ligths = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light ligth in ligths)
        {
            ligth.enabled = false;
        }

        RenderSettings.ambientLight = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
