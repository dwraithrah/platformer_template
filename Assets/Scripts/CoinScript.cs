using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    //object that detects collisions with player
    private Collider player;
    private Collider coin;

	// Use this for initialization
	void Start () {

        //assigns collider object the collider for the player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>();
        coin = this.gameObject.GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

        //if there is a collision, destroy the coin and add +10 to the score.
        
	}

    private void OnTriggerEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this);
        }
    }


}
