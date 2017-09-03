using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the player controller class will handle all of the controls tied to the player. Moving left. Moving right. Jumping.

public class PlayerController : MonoBehaviour {

    //this variable will set how fast player will move when moving in one direction or the other
    public float speed = .25f;
    public float jumpValue = 15f;


    private Rigidbody2D playerBody;



    // Use this for initialization
    void Start () {
        playerBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        //move right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 position = this.transform.position;

            //takes the current x-position on the grid and adds one to it
            position.x += speed;

            //changes position of player to the new x position
            this.transform.position = position;
        }

        //move left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //get current position. Using Vector2 because this is 2d. Only 2 vectors
            Vector2 position = this.transform.position;

            //takes the current x-position on the grid and adds one to it
            position.x -= speed;

            //changes position of player to the new x position
            this.transform.position = position;
        }

        //jump in air by hitting space bar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector2.up * jumpValue, ForceMode2D.Impulse);
        }

        
	}
}
