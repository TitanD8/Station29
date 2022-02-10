using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SceneStats : ScriptableObject
{
    public int SceneTemp;

    public int GetTemp()
    {
        return SceneTemp;
    }
}
