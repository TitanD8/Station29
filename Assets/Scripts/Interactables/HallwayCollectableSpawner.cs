using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayCollectableSpawner : MonoBehaviour
{
    // CONFIG DATA
    [Tooltip("This prefab will only be spawned once and persisted between " +
    "scenes.")]

    [SerializeField] GameObject OfficeKeyPrefab = null;

    // PRIVATE STATE
    public static bool OfficeKeyCollected = false;

    //PRIVATE
    private void Awake()
    {
        if (OfficeKeyCollected) return;

        SpawnCollectables();
    }

    private void SpawnCollectables()
    {
        GameObject OfficeKey = Instantiate(OfficeKeyPrefab);
        OfficeKey.name.Replace("(Clone)", "");


    }
}
