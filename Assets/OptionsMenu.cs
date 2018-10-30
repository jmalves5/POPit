using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This class contains all the objects present in the Options Menu
public class OptionsMenu : MonoBehaviour
{
    //Declare Sliders
    public Slider MaxObjectsSlider;
    public Slider MaxVelocitySlider;
    public Slider SpawningRateSlider;
    public Slider TTLSlider;
    public Slider inibImpProbSlider;
    public Toggle inibImpToggle;
    public Toggle TTLUnlimit;

    public Text MaxObjectstext;
    public Text MaxVelocitytext;
    public Text SpawningRatetext;
    public Text ObjectTTLtext;
    public Text inibImpProbText;

    //On awake get current value to the sliders
    public void Start()
    {
        GetGameControlValues();
    }

    public void GetGameControlValues()
    {
        MaxObjectsSlider.value = GameControl.control.getNObjects();
        MaxVelocitySlider.value = GameControl.control.getVelocity()/100;
        SpawningRateSlider.value = GameControl.control.getSpawnRate();
        TTLSlider.value = GameControl.control.getObjectTTL();
        TTLUnlimit.isOn = GameControl.control.getTTLUnlimit();
        inibImpProbSlider.value = GameControl.control.GetImpulseInibitionProb();
        inibImpToggle.isOn = GameControl.control.GetImpulseInibitionBool();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Update()
    {
        GameControl.control.SetNObjects(MaxObjectsSlider.value);
        GameControl.control.SetVelocity(MaxVelocitySlider.value*100);
        GameControl.control.SetSpawnRate(SpawningRateSlider.value);

        GameControl.control.SetTTLUnlimit(TTLUnlimit.isOn);
        GameControl.control.SetImpulseInibition(inibImpToggle.isOn);
   
        MaxObjectstext.text = MaxObjectsSlider.value.ToString();
        MaxVelocitytext.text = MaxVelocitySlider.value.ToString();
        SpawningRatetext.text = SpawningRateSlider.value.ToString();
        
        
        if (!TTLSlider.enabled)
        {
            ObjectTTLtext.text = "\u221E"; //simbolo de infinito
            GameControl.control.SetObjectTTL(360000); //100 hours == infinito. IF VALUE CHANGED CHANGE TTLToggle.cs --> Start() ACCORDINGLY
        }else {
            ObjectTTLtext.text = TTLSlider.value.ToString();
            GameControl.control.SetObjectTTL(TTLSlider.value);

        }

        if (!inibImpProbSlider.enabled)
        {
            inibImpProbText.text = 0.ToString();
            GameControl.control.SetInibImpProb(0f);
        }
        else
        {  
            inibImpProbText.text = inibImpProbSlider.value.ToString();
            GameControl.control.SetInibImpProb(inibImpProbSlider.value);
        }

    }
}