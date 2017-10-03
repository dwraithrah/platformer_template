using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour {


    
    
    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //if collide pick-up power-up 
    void OnTriggerEnter2D(Collider2D other)
    {
        //if player collider runs into coin collider, destroy coin
        if (other.gameObject.CompareTag("Player"))
        {
            //pick up powerup
            Destroy(gameObject);
            InventoryControl.hasInventory = true;

        }

    }
}
