using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTLToggle : MonoBehaviour
{
    public Slider TTLSlider;
    public Text TTLText;

    public void ToggleEnable()
    {
        TTLSlider.enabled = !TTLSlider.enabled;
        if (!TTLSlider.enabled) {
            TTLText.text = "Infinito";
        }
    }
}
