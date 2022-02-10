using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Static Reference That Can Be Used By Other Scripts
    public static UIController Ui;

    [Header("World Temperature UI", order = 0)]
    [SerializeField]
    private Slider _worldTemperatureSlider;
    [SerializeField]
    private Image[] _worldTemperatureSliderFills;
    //[SerializeField]
    //private Text _currentWorldTemperatureText;

    [Header("Player Status UI", order = 1)]
    [SerializeField]
    private Slider _healthSlider;
    [SerializeField]
    private Image[] _healthSliderFills;
    //[SerializeField]
    //private Text _healthText;

    [SerializeField]
    private Slider _bodyTemperatureSlider;
    [SerializeField]
    private Image[] _bodyTemperatureFills;
   // [SerializeField]
    //private Text _bodyTemperatureText;

    [Header("Suit Status UI", order = 2)]
    [SerializeField]
    private Slider _powerRemainingSlider;
    //[SerializeField]
    //private Text _powerRemainingText;
    
    [SerializeField]
    private Slider _climateControlSlider;
    //[SerializeField]
    //private Text _climateControlText;


    private void Awake()
    {
        Ui = this.GetComponent<UIController>();
    }

    #region WorldUI
    public void UpdateWorldTempertureUI(int currentWorldTemperature)
    {
        if (currentWorldTemperature == 0)
        {
            _worldTemperatureSlider.value = currentWorldTemperature;
            _SetSliderColour(_worldTemperatureSliderFills, Color.white);
            //_currentWorldTemperatureText.text = "Normal";
        }
        else if (currentWorldTemperature == -1)
        {
            _worldTemperatureSlider.value = currentWorldTemperature;
            _SetSliderColour(_worldTemperatureSliderFills, Color.cyan);
            //_currentWorldTemperatureText.text = "Cold";
        }
        else if (currentWorldTemperature == -2)
        {
            _worldTemperatureSlider.value = currentWorldTemperature;
            _SetSliderColour(_worldTemperatureSliderFills, Color.blue);
            //_currentWorldTemperatureText.text = "Freezing";
        }
        else if (currentWorldTemperature == 1)
        {
            _worldTemperatureSlider.value = currentWorldTemperature;
            _SetSliderColour(_worldTemperatureSliderFills, Color.yellow);
            //_currentWorldTemperatureText.text = "Hot";
        }
        else if (currentWorldTemperature == 2)
        {
            _worldTemperatureSlider.value = currentWorldTemperature;
            _SetSliderColour(_worldTemperatureSliderFills, Color.red);
            //_currentWorldTemperatureText.text = "Extremely Hot";
        }
    }

    //TempFunction For Testing
    public int GetWorldTempertureFromUI()
    {
        int newWorldTemperature = ((int)_worldTemperatureSlider.value);
        return newWorldTemperature;
    }
    #endregion

    #region SuitUI
    public void UpdateClimateControlUI(int climateControlLevel)
    {
        if (climateControlLevel == -1)
        {
            _climateControlSlider.value = climateControlLevel;
            //_climateControlText.text = "Venting";
        }
        else if (climateControlLevel == 0)
        {
            _climateControlSlider.value = climateControlLevel;
            //_climateControlText.text = "Off";
        }
        else if (climateControlLevel == 1)
        {
            _climateControlSlider.value = climateControlLevel;
            //_climateControlText.text = "Low";
        }
        else if (climateControlLevel == 2)
        {
            _climateControlSlider.value = climateControlLevel;
            //_climateControlText.text = "High";
        }
    }

    public void UpdatePowerRemainingUI(int powerRemaining)
    {
        _powerRemainingSlider.value = powerRemaining;
        //_powerRemainingText.text = powerRemaining.ToString() + "%";
    }
    #endregion

    #region PlayerUI
    public void UpdatePlayerHealthUI(int health)
    {
        if (health >= 66)
        {
            _SetSliderColour(_healthSliderFills, Color.green);
        }
        else if (health > 33 && health < 66)
        {
            _SetSliderColour(_healthSliderFills, Color.yellow);
        }
        else if (health <= 33)
        {
            _SetSliderColour(_healthSliderFills, Color.red);
        }

        _healthSlider.value = health;
        //_healthText.text = health.ToString() + "%";
    }

    public void UpdateBodyTemperatureUI(int bodyTemperature)
    {
        if (bodyTemperature == 0 || bodyTemperature == 1)
        {
            _SetSliderColour(_bodyTemperatureFills, Color.white);
            //_bodyTemperatureText.text = "Normal";
        }
        else if (bodyTemperature == 2)
        {
            _SetSliderColour(_bodyTemperatureFills, Color.red);
            //_bodyTemperatureText.text = "Overheating";
        }
        else if (bodyTemperature == -1)
        {
            _SetSliderColour(_bodyTemperatureFills, Color.cyan);
            //_bodyTemperatureText.text = "Cold";
        }
        else if (bodyTemperature == -2)
        {
            _SetSliderColour(_bodyTemperatureFills, Color.blue);
            //_bodyTemperatureText.text = "Freeing";
        }
        _bodyTemperatureSlider.value = bodyTemperature;
    }
    #endregion

    private void _SetSliderColour(Image[] Fills, Color colour)
    {
        foreach (Image fill in Fills)
        {
            fill.color = colour;
        }
    }

}
