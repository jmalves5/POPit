﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTLToggle : MonoBehaviour
{
    public Slider TTLSlider;
    public Text TTLText;
  

    public void Start()
    {
        if (GameControl.control.getObjectTTL()==360000)
        {
            this.GetComponentInParent<Toggle>().isOn = true;
        }
        else
        {
            this.GetComponentInParent<Toggle>().isOn = false;
        }
    }

    public void ToggleEnable()
    {
        TTLSlider.enabled = !TTLSlider.enabled;
    }
}