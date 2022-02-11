using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitStats : MonoBehaviour
{
    public PersistantPlayerStats persistantStats;

    public int climateControlLevel = 0;
    public int maxLevel = 2;
    public int minLevel = -1;

    public int powerRemaining = 100;
    public int powerDrain;
    public bool powerDraining = false;

    public void Start()
    {
        climateControlLevel = persistantStats.storedClimateControlLevel;
        UIController.Ui.UpdateClimateControlUI(climateControlLevel);
        powerDrain = persistantStats.storedPowerDrain;
        powerRemaining = persistantStats.storedPowerRemaining;
        UIController.Ui.UpdatePowerRemainingUI(powerRemaining);
    }

    public void DecreaseClimateControl()
    {
        if (IsInvoking("ApplyPowerDrain"))
        {
            CancelInvoke("ApplyPowerDrain");
            powerDraining = false;
            Debug.Log("Invoke Cancelled (SuitStats)");
        }

        if (climateControlLevel > minLevel)
        {
            climateControlLevel = climateControlLevel - 1;
            UIController.Ui.UpdateClimateControlUI(climateControlLevel);
            if (climateControlLevel == 1)
            {
                powerDrain = powerDrain - 1;
            }
            if (climateControlLevel == 0)
            {
                powerDrain = powerDrain - 1;
            }
        }
    }

    public void IncreaseClimateControl()
    {
        if(IsInvoking("ApplyPowerDrain"))
        {
            CancelInvoke("ApplyPowerDrain");
            powerDraining = false;
            Debug.Log("Invoke Cancelled (SuitStats)");
        }

        if(climateControlLevel < maxLevel)
        {
            climateControlLevel = climateControlLevel + 1;
            UIController.Ui.UpdateClimateControlUI(climateControlLevel);
        }
        if(climateControlLevel == 1)
        {
            powerDrain = powerDrain + 1;
        }
        if(climateControlLevel == 2)
        {
            powerDrain = powerDrain + 1;
        }
    }

    public void ApplyPowerDrain()
    {
        powerRemaining = powerRemaining - powerDrain;
        UIController.Ui.UpdatePowerRemainingUI(powerRemaining);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseClimateControl();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DecreaseClimateControl();
        }

        if (powerDrain > 0 && powerDraining == false)
        {
            InvokeRepeating("ApplyPowerDrain", 1f, 1f);
            powerDraining = true;
        }
        else if(powerDrain <= 0 && powerDraining == true)
        {
            CancelInvoke("ApplyPowerDrain");
            powerDraining = false;
            Debug.Log("Invoke Cancelled (SuitStats)");
        }
    }

    private void OnDisable()
    {
        persistantStats.storedClimateControlLevel = climateControlLevel;
        persistantStats.storedPowerRemaining = powerRemaining;
        persistantStats.storedPowerDrain = powerDrain;
    }

}
