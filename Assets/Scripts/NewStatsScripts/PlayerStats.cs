using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //TEMP

public class PlayerStats : MonoBehaviour
{
    public PersistantPlayerStats lastStats;
    public int bodyTemperature = 0;
    public int healthRemaining = 100;
    public Weather weather;
    public SuitStats2 suit;
    public bool damagingWeather;

    private void Start()
    {
        suit = GetComponentInChildren<SuitStats2>();
        weather = GameObject.FindGameObjectWithTag("Weather").GetComponent<Weather>();
        healthRemaining = lastStats.currentHealth; //PersistantStats.storedHealth;
        UIController.Ui.UpdatePlayerHealthUI(healthRemaining);
    }

    private void Update()
    {
        bodyTemperature = suit.climateControlLevel + weather.currentWeather;
        UIController.Ui.UpdateBodyTemperatureUI(bodyTemperature);
        CheckWeatherResistance();
    }

    public void CheckWeatherResistance()
    {
        if (bodyTemperature != 0 && bodyTemperature != 1)
        {
            if (damagingWeather == false)
            {
                InvokeRepeating("ApplyColdDamage", 1f, 1f);
                damagingWeather = true;
            }

        }
        else
        {
            if (damagingWeather == true)
            {
                CancelInvoke("ApplyColdDamage");
                damagingWeather = false;
            }
        }
    }

    public void OnDisable()
    {
        /*PersistantStats.storedHealth*/ lastStats.currentHealth = healthRemaining;
    }

    public void ApplyColdDamage()
    {
        if (bodyTemperature > 1)
        {
            bodyTemperature = 1;
        }

        if (bodyTemperature < 0)
        {
            healthRemaining += bodyTemperature;
            UIController.Ui.UpdatePlayerHealthUI(healthRemaining);
        }
        else
        {
            healthRemaining -= bodyTemperature;
            UIController.Ui.UpdatePlayerHealthUI(healthRemaining);
        }
    }
}


