using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class _Stats : MonoBehaviour
{
    [Header("Temperature Controls")]
    public Slider worldTempSlider; // references a UI slider to change the world temperature.
    public Image[] worldTempSliderFills; // holds the images that are to be recoloured based on the current World Temperature.
    public Text currentWorldTempText; // References a UI text object which shows the current World Temperature Sliders Value.
    public int currentWorldTemp; // An int to hold the currentWorldTemp.

    [Header("Player Stats")]
    public Slider healthSlider;
    public Image[] healthSliderFills;
    public Text healthText;
    public int health = 100;

    public Slider bodyTempSlider;
    public Image[] bodyTempSliderFills;
    public Text bodyTempText;

    public int bodyTemp = 0;
    public bool damagingCold = false;
    public UnityEvent onBodyTempChange;

    [Header("Suit Stats")]
    public int power = 100;
    public bool powerIsDraining = false;
    public Slider powerMetreSlider;
    public Text powerMetreText;

    public Slider heaterTempSlider;
    public Text heaterTempText;
    public int heaterTemp = 0;

    private void Start()
    {
        worldTempSlider.onValueChanged.AddListener(UpdateWorldTemp);
        heaterTempSlider.onValueChanged.AddListener(UpdateHeaterTemp);
    }

    //Function used for colouring sliders.
    public void SetSliderColour(Image[] Fills, Color colour)
    {
        foreach (Image fill in Fills)
        {
            fill.color = colour;
        }
    }

    //Sets the currentWorldTemp off of the Slider Value.
    //Sets Slider colour to represent temp levels: freezing(blue), cold(cyan), normal(white), warm(yellow) and hot(red).
    public void UpdateWorldTemp(float worldTemp)
    {
        currentWorldTemp = ((int)worldTemp);
        currentWorldTempText.text = currentWorldTemp.ToString();
        

        if(currentWorldTemp == 0)
        {
            //currentWorldTempSlider.value = currentWorldTemp;
            SetSliderColour(worldTempSliderFills, Color.white);
        }
        else if(currentWorldTemp == -1)
        {
            //currentWorldTempSlider.value = currentWorldTemp;
            SetSliderColour(worldTempSliderFills, Color.cyan);
        }
        else if(currentWorldTemp == -2)
        {
            //currentWorldTempSlider.value = currentWorldTemp;
            SetSliderColour(worldTempSliderFills, Color.blue);
        }
        else if (currentWorldTemp == 1)
        {
            //currentWorldTempSlider.value = currentWorldTemp;
            SetSliderColour(worldTempSliderFills, Color.yellow);
        }
        else if (currentWorldTemp == 2)
        {
            //currentWorldTempSlider.value = currentWorldTemp;
            SetSliderColour(worldTempSliderFills, Color.red);
        }
    }

    public void UpdateHeaterTemp(float heaterLevel)
    {
        heaterTemp = ((int)heaterLevel);
        CancelInvoke("PowerDrain");

        if (heaterTemp == -1)
        {
            heaterTempText.text = "Venting";
           
            
        }
        else if (heaterTemp == 0)
        {
            heaterTempText.text = "Off";
            
        }
        else if (heaterTemp == 1)
        {
            heaterTempText.text = "Low";
            //powerIsDraining = true;
            InvokeRepeating("PowerDrain", 1f, 1f);

        }
        else if (heaterTemp == 2)
        {
            heaterTempText.text = "High";
            //powerIsDraining = true;
            InvokeRepeating("PowerDrain", 1f, 1f);
        }
    }

    public void PowerDrain()
    {
        power -= heaterTemp;
        powerMetreSlider.value = power;
        powerMetreText.text = power.ToString() + "%";
    }

    public void ColdDamage()
    {
        if(bodyTemp > 1)
        {
            bodyTemp = 1;
        }

        if (bodyTemp < 0)
        {
            health += bodyTemp;
        }
        else
        {
            health -= bodyTemp;
        }
        healthSlider.value = health;
        healthText.text = health.ToString() + "%";
    }

    public void HealthBarColourCheck()
    {
        if(health >= 66)
        {
            SetSliderColour(healthSliderFills, Color.green);
        }
        else if(health > 33 && health < 66)
        {
            SetSliderColour(healthSliderFills, Color.yellow);
        }
        else if (health <= 33)
        {
            SetSliderColour(healthSliderFills, Color.red);
        }        
    }
    
    public void SetBodyTempSliderColourAndText()
    {
        if (bodyTemp == 0 || bodyTemp == 1)
        {
            SetSliderColour(bodyTempSliderFills, Color.white);
            bodyTempText.text = "Normal";
        }
        else if (bodyTemp == 2)
        {
            SetSliderColour(bodyTempSliderFills, Color.red);
            bodyTempText.text = "Overheating";
        }
        else if(bodyTemp == -1)
        {
            SetSliderColour(bodyTempSliderFills, Color.cyan);
            bodyTempText.text = "Cold";
        }
        else if(bodyTemp == -2)
        {
            SetSliderColour(bodyTempSliderFills, Color.cyan);
            bodyTempText.text = "Cold";
        }
    }

    private void Update()
    {
        // Turns of Heater if Power Runs Out
        if (powerMetreSlider.value <= 0)
        {
            heaterTempSlider.value = 0;
        }

        //Set Body Temp
        bodyTemp = currentWorldTemp + heaterTemp;
        bodyTempSlider.value = bodyTemp;

        //Checks if in danger of cold damage
        if(bodyTemp != 0 && bodyTemp !=1)
        {
            if(damagingCold == false)
            {
                InvokeRepeating("ColdDamage", 1f, 1f);
                damagingCold = true;
            }
            
        }
        else
        {
            if(damagingCold == true)
            {
                CancelInvoke("ColdDamage");
                damagingCold = false;
            }
        }
    }

}
