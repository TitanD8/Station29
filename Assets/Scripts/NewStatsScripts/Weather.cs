using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //TEMP

public class Weather : MonoBehaviour
{
    public SceneStats levelWeather;
    public int currentWeather = 0;
    private int _maxWeather = 2;
    private int _minWeather = -2;

    private void Start()
    {
        if(levelWeather != null)
        {
            currentWeather = levelWeather.SceneTemp;
            UIController.Ui.UpdateWorldTempertureUI(currentWeather);
        }
        else
        {
            UIController.Ui.UpdateWorldTempertureUI(currentWeather);
        }
    }

    public void SetWeather()
    {
        UIController.Ui.UpdateWorldTempertureUI(currentWeather);
    }

    public void DecreaseTemperature()
    {
        if(currentWeather > _minWeather)
        {
            currentWeather = currentWeather - 1;
            UIController.Ui.UpdateWorldTempertureUI(currentWeather);
        }
        else { return; }
    }

    public void IncreaseTemperature()
    {
        if (currentWeather < _maxWeather)
        {
            currentWeather = currentWeather + 1;
            UIController.Ui.UpdateWorldTempertureUI(currentWeather);
        }
        else { return; }
    }
}
