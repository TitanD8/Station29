using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantSpawner : MonoBehaviour
{
    // CONFIG DATA
    [Tooltip("This prefab will only be spawned once and persisted between " +
    "scenes.")]
    [SerializeField] GameObject persistantCharacterPrefab = null;
    [SerializeField] GameObject persistantSceneChangerPrefab = null;
    [SerializeField] GameObject persistantMainCameraPrefab = null;

    // PRIVATE STATE
    public static bool hasSpawned = false;

     //PRIVATE
    private void Awake()
    {
        if (hasSpawned) return;

        SpawnPersistentObjects();

        hasSpawned = true;
    }

    private void SpawnPersistentObjects()
    {
        GameObject persistentCharacter = Instantiate(persistantCharacterPrefab);
        DontDestroyOnLoad(persistentCharacter);

    }
}
