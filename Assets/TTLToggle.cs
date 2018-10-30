using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTLToggle : MonoBehaviour
{
    public Slider TTLSlider;
    public Text TTLText;
  

    public void Start()
    {
        if (GameControl.control.getTTLUnlimit())
        {
            this.GetComponentInParent<Toggle>().isOn = false;
        }
        else
        {
            this.GetComponentInParent<Toggle>().isOn = true;
        }
    }

    public void ToggleEnable()
    {
        TTLSlider.enabled = !TTLSlider.enabled;
    }

    public void ToggleOn()
    {
        TTLSlider.enabled = true;
    }

    public void ToggleOff()
    {
        TTLSlider.enabled = false;
    }
}
