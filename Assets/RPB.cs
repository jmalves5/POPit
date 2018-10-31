using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RPB : MonoBehaviour {

    public Transform LoadingBar;
    private MyCursor myCursor;
    
    [SerializeField] public float currentAmount;
    [SerializeField] private float speed = 50;  //MUST BE CUSTOMIZABLE

    public void Start()
    {
        myCursor = GameControl.FindObjectOfType<MyCursor>();
    }

    // Update is called once per frame
    public void Update () {
        
        if (GameControl.control.GetBSV().IsTracked())  //Solucionar RPB
        {
            Vector3 offset = new Vector3(0, 0, 1);
            this.transform.position = myCursor.transform.position + offset;
   
        }
        else {
            
            this.transform.position = GameControl.control.MyCursor.transform.position;

        }

        
  
        if (currentAmount < 100)
        {
            currentAmount += speed * Time.deltaTime;
        }
        LoadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;
	}
}
