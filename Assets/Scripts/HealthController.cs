using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public Slider  mainSlider;  //slider object to adjust slider bar for health
 

	// Use this for initialization
	void Start () {
 
	}
	
	// Update is called once per frame
	void Update () {

        //will check data holder for current health and update slider
        mainSlider.value = DataHolderController.playerHealth;
	}
}
