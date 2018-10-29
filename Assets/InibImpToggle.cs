using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InibImpToggle : MonoBehaviour
{
    public Slider InibImpSlider;

    public void Start()
    {
        if (GameControl.control.GetImpulseInibitionBool())
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
        InibImpSlider.enabled = !InibImpSlider.enabled;
        GameControl.control.ToggleImpulseInibition();
    }
}
