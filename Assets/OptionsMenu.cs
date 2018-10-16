using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This class contains all the objects present in the Options Menu
public class OptionsMenu : MonoBehaviour
{
    //Declare Sliders
    public UnityEngine.UI.Slider MaxObjectsSlider;
    public UnityEngine.UI.Slider MaxVelocitySlider;

    //On awake get current value to the sliders
    public void Start()
    {
        GetGameControlValues();
    }

    public void GetGameControlValues()
    {
        MaxObjectsSlider.value = GameControl.control.getNObjects();
        MaxVelocitySlider.value = GameControl.control.getVelocity()/100;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateControlValues()
    {
        GameControl.control.SetNObjects(MaxObjectsSlider.value);
        GameControl.control.SetVelocity(MaxVelocitySlider.value * 100);
    }
}