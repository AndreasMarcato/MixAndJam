using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_JumpingGame : MonoBehaviour
{
    //--This will create a circle under player that will detect if the player is touching the ground
    //--For this remember to add empty game object (CheckGround) and move it under the player. Remember to give it Gizmos to see it easily
    //--Drag and drop CheckGround in groundCheck
    //--Also give all the ground objects layer named Ground and choose that in Sorting Layer. That will be used to determine what is ground

    //--Reference to rigidbody 
    public new Rigidbody rigidbody;
    //--Force applied to Rigidbody to make player jump
    public float jumpForce = 6;
    public float extraJumpForce = 6;    //--This one is the force for second jump!

    //--Check if player is on the ground
    private bool isGrounded;


    //--Double Jump
    private int extraJumps;
    public int extraJumpValue;

    //-------------------
    public GameController_JumpingGame gCJumpingGame;   


    //--Use this for intializaion
    private void Start()
    {
        //--Sets jump into value it was given (1), meaning we get one extra jump and can double jump
        extraJumps = extraJumpValue;
        //-- Get rb
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    private void Update()
    {
        //--If we are on the ground we have one extra jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        //-- if you touch the screen, player will jump max 2 times
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && extraJumps > 0)
        {
            Debug.Log("I was herr");
                //--Then apply the force to Rigidbody to make player jump
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                //--when you are in the air and jump again you will lose your extra jump
                extraJumps--;
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && extraJumps == 0 && isGrounded == true)
        {
            Debug.Log("In the other one?");
            //--if we are on the ground and jump
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    //--Game Over happens here if player hits object
    private void OnCollisionEnter(Collision collision)
    {
        //--If the object has GameOver tag, player loses
        if (collision.collider.CompareTag("GameOver"))
        {
            Destroy(this.gameObject);
            GameController_JumpingGame.isGameOver = true;   //--Show Game Over screen. isGameOver is in GameController_JumpingGame script
            GameController_JumpingGame.isPaused = true;     //--Game is paused
            gCJumpingGame.pauseGame();                      //--Call the pause to happen
        }

        //--If player is on the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //--If player is not on the ground
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
