using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public PersistantPlayerStats persistantStats;
    public bool NewGame;


    void Awake()
    {
     if(NewGame)
        {
            persistantStats.storedHealth = 100;
            persistantStats.storedClimateControlLevel = 0;
            persistantStats.storedPowerDrain = 0;
            persistantStats.storedPowerRemaining = 100;
            NewGame = false;
        }
        SceneManager.LoadScene(1);
    }
}
