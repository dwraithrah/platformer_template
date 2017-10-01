using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//The code for this script was taken from the Unity 2d platformer tutorial at https://unity3d.com/learn/tutorials/topics/2d-game-creation/creating-basic-platformer-game
//comments added to help explain the code.  

//the player controller class will handle all of the controls tied to the player. Moving left. Moving right. Jumping.

public class PlayerController : MonoBehaviour {


    //hide in inspector makes it to where you can have a public variable but it won't show up in the unity inspector.
    [HideInInspector] public bool jump = false;//tells if player is jumping or not

    //these public variables can be adjusted in the inspector for easier testing of values .
    public float moveForce = 365f;//used to calculate move speed and acceleration
    public float maxSpeed = 5f; //used to cap acceleration so player can only move so fast.
    public float jumpForce = 650;   //used to calculate how high and far the player can jump.
    public Transform groundCheck; //tells if player is staying on ground




    private bool grounded = false; //tells if player is grounded or not
    // private Animator anim;   //Stores component reference to animator.  commented out due to lack of animation in this example.
    private Rigidbody2D rb2d;  //Will store reference to rigid body



    // Use this for initialization when script is loadede, before game starts. 
    void Awake () {
        //attach component's animator to anim
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();  //attach component's rigid body to rb2d

	}

  

    // Update is called once per frame as needed (not at a constant rate)
    void Update () {
        //the following bit of code causes the game to cast a ray from where the player is (transform.position), transfers it to groundCheck, and checks it against 
        //any layer that's labelled as "Ground" to see if player is on the ground or not. 
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        //checks if grounded and if the jump button was pressed. If both conditions are true, then jump will be set to true.
        if(Input.GetButtonDown("Jump") && grounded)
        {
            jump = true; 
        }

        //checks if player has fallen off a platform and resets the stage
        if(this.transform.position.y <= -20)
        {
            //will reload current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //checks if player health hits 0. Resets scene if it has.
        if(DataHolderController.playerHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    //fixed update is updated every .02 seconds.  Used for code involving physics
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); //store horizontal axis info in h, a value of -1 to 1.

        //anim.SetFloat("Speed", Mathf.Abs(h));//accesses the speed of the animation and sets it from a value of 0 to 1.

        if ((h * rb2d.velocity.x) < maxSpeed)//checks to see if player is currently going slower than max speed. 
        {
            //if it is going slower than max speed
            rb2d.AddForce(Vector2.right * h * moveForce);//adds a positive force to the player to increase acceleration. 
                                                         //note since h can become negative, when going left it will actually deccelerate the player.
        }

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)//checking to see if going faster than max speed
        {
            //this fun bit of math code checks to see if you're going left or right then sets the player at max velocity speed. -speed = left, +speed = right. 
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        //this next slice of commented out code can be used to figure out which way player is facing, then calls the commented out Flip function.
        /*
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();*/

        if (jump)//if jump is set to true. See conditions in update function
        {
            //anim.SetTrigger("Jump"); //This code will cause a jump animation to play if there is one
            rb2d.AddForce(new Vector2(0f, jumpForce));//adds built in jump force from unity to create a jump
            jump = false;//resets jump to false so no double jumping allowed 
        }
    }

    //if player collides with enemy player loses health
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {

            DataHolderController.playerHealth -= 1;

        }
    }


    //this function, when called, will check which way the player is facing for purposes of changing sprites
    /*void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }*/
}
