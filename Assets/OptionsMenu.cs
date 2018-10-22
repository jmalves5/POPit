using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//This class contains all the objects present in the Options Menu
public class OptionsMenu : MonoBehaviour
{
    //Declare Sliders
    public UnityEngine.UI.Slider MaxObjectsSlider;
    public UnityEngine.UI.Slider MaxVelocitySlider;
    public UnityEngine.UI.Slider SpawningRateSlider;

    public Text MaxObjectstext;
    public Text MaxVelocitytext;
    public Text SpawningRatetext;

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
        GameControl.control.SetSpawnRate(SpawningRateSlider.value);
        MaxObjectstext.text = MaxObjectsSlider.value.ToString();
        MaxVelocitytext.text = MaxVelocitySlider.value.ToString();
        SpawningRatetext.text = SpawningRateSlider.value.ToString();
    }
}