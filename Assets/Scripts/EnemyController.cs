using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {


    //needed to move enemy back and forth
    public enum OccilationFuntion { Sine, Cosine }

 
    bool dirLeft;

    public float moveSpeed = 1.0f;

    private void Awake()
    {
      
    }

    // Use this for initialization
    void Start () {
     
        dirLeft = true; //enemy starts moving left
  
    }

    // Update is called once per frame
    void Update () {


        //script to make enemy move back and forth
        if(dirLeft)//if headed left
        {
            transform.Translate(-Vector2.right * moveSpeed * Time.deltaTime); //keep moving left
        }
        else //if headed right
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "Player") //if collide with anything other than player
        {
            dirLeft = !dirLeft; //if enemy runs into something not the player, change from false to true or vice versa
        }
    }




}
