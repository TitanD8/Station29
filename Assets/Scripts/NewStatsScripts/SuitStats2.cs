using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitStats2 : MonoBehaviour
{
    public int climateControlLevel = 0;
    public int maxLevel = 2;
    public int minLevel = -1;

    public int powerRemaining = 100;
    public bool powerDraining = false;

    public void Start()
    {
        climateControlLevel = PersistantStats.storedClimateControlLevel;
        UIController.Ui.UpdateClimateControlUI(climateControlLevel);
        powerRemaining = PersistantStats.storedPower;
        UIController.Ui.UpdatePowerRemainingUI(powerRemaining);
    }

    public void DecreaseClimateControl()
    {
        if(climateControlLevel > minLevel)
        {
            climateControlLevel = climateControlLevel - 1;
            UIController.Ui.UpdateClimateControlUI(climateControlLevel);
        }
    }

    public void IncreaseClimateControl()
    {
        if(climateControlLevel < maxLevel)
        {
            climateControlLevel = climateControlLevel + 1;
            UIController.Ui.UpdateClimateControlUI(climateControlLevel);
        }
    }

    public void ApplyPowerDrain()
    {
        powerRemaining = powerRemaining - climateControlLevel;
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

        if (climateControlLevel > 0 && powerDraining == false)
        {
            InvokeRepeating("ApplyPowerDrain", 1f, 1f);
            powerDraining = true;
        }
        else if (climateControlLevel < 0 && powerDraining == true)
        {
            CancelInvoke("ApplyPowerDrain");
            powerDraining = false;
        }
        else { return; }
    }

    private void OnDisable()
    {
        PersistantStats.storedClimateControlLevel = climateControlLevel;
        PersistantStats.storedPower = powerRemaining;
    }

}
