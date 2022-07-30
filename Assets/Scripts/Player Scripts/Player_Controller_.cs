using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_ : MonoBehaviour
{
public float MovementSpeed = 1;
// Allows you to adjust the movement speed via the editor
public float JumpStrength = 1;
// Allows you to adjust the jump strength via the editor
public bool CanJump;
// Tells you whether or not the player is able to jump
public Animator am;
// Defines my Animator as am and allows you to drag your animator into a new section in your script 
// which is below my modifications for movementspeed and jump strength.
// I can drag my animator into it in order to reference it and use it in this script
private Rigidbody2D rb;
// Defines variable rb as Rigidbody2D, this is made private 
// so that only this section of code can use it
const float groundCheckRadius = 0.2f;
//Stores groundCheckRadius as 0.2f to be used in the groundCheckRadius array.
[SerializeField] public bool isGrounded = false;
// Sets isGrounded to false by default
[SerializeField] Transform groundCheckCollider;
// Need to get the trasnform object as it is used for positioning
// Serialized so that it can be references from the inspector in the editor
[SerializeField] LayerMask groundLayer;
// Serialized so that it is modifiable from the editor
// References the GroundLayer in the scripts of the ground objects
[SerializeField] LayerMask deathLayer;
// References the EnvironmentLayer in the script
[SerializeField] public bool deathEnLayer = false;
// Sets deathEnLayer to false


    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         //Links Rigidbody2D component to script
         am = GetComponent<Animator>(); 
         //Links Animator component to script

    }

    // Update is called once per frame
    void Update()
    {

      DeathCheck();
      // Calls DeathCheck method

      GroundCheck();
      // Calls GroundCheck method

      am.SetFloat ("yVelocity", rb.velocity.y);
      //set the yVelocity in the animator

      am.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
      // Sets the horizontal animation parameter so that when the player moves in a 
      // direction the animation transition occurs

      var movement = Input.GetAxis("Horizontal");
      // Makes use of the default horizontal input axis which returns 1 for the D 
      // (Right Arrow Key) key and -1 for the A Key (Left Arrow Key)

      transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;
      // Creates a new Vector3 with the X-axis to set our input value and you multiply 
      // that by Time.deltaTime to smoothen out movement over the frames

      if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
      //Flips the sprite when moving into a different direction

      if ( (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)) && CanJump)
      // Uses default input system for jump action by using GetButtonDown
      // CanJump links the CanJump boolean to the jump input command
      // Additionally has the W key set as a Input for jumping
        {
		 FindObjectOfType<AudioManager>().Play("Player Jump");
           // Plays audio sound effect for jumping
           rb.AddForce(new Vector2(0, JumpStrength), ForceMode2D.Impulse);
           //Adds force in the Y-Axis and creates a variable called JumpStrength which 
           // I have also made a float to be modified in the editor

           am.SetBool("IsJump", true);
           //This tells the animator to play the animation when my player is entering the jumping motion
        }

void GroundCheck()
{
     isGrounded = false;
     //Set default to isGrounded = false so that when you jump the isGrounded box in the insecptor is unticked
     //Check if the GroundCheckObject is colliding with other
     //2D Colliders that are in the "Ground" Layer
     //If yes (Is Grounded = true) else (isGrounded = false)
     Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
     //Array which holds the values of the groundCheckCollider position, groundCheck Radius, and the groundLayer.
     //Physics2D.OverlapCircleAll, All is written so that everything in the ground object is checked and not just one thing
     if(colliders.Length>0)
      isGrounded = true; 
     //if statement checks for entries in the array
     //if entry length is bigger than 0 then the player is grounded hence isGrounded = true;

     am.SetBool("IsJump", !isGrounded);
     // As long as we are grounded the "Jump" bool is in the animator is disabled so the jump animation doesn't play

}
if(isGrounded == true){

CanJump = true;

}
else{

CanJump = false;
// An if else statement which says whether the player can jump or not depending on whether they are grounded
// If the player is grounded then the player can jump
// If the player is not grounded then player can't jump

}

void DeathCheck()
{
     deathEnLayer = false;
     //Set default to deathEnLayer = false 
     //Check if the GroundCheckObject touches the "EnvironemntDeath" layer 
     Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, deathLayer);
     // Array which holds the values of the groundCheckCollider position, groundCheck Radius, and the deathLayer.
     // Physics2D.OverlapCircleAll, All is written so that everything in the ground object is checked and not just one thing
     if(colliders.Length>0)
     deathEnLayer = true;
     // if statement checks for entries in the array
     // if entry length is bigger than 0 then the player is grounded hence deathEnLayer = true;
}
if (deathEnLayer == true)
{
     GetComponent<Player_Health>().Death();
     // If the player touches the EnvironmentDeathLayer the Death method in my 
     // Player_Health script is called
}
}
}
