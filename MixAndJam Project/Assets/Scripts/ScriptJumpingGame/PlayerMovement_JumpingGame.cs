using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_JumpingGame : MonoBehaviour
{
    //--This will create a circle under player that will detect if the player is touching the ground
    //--For this remember to add empty game object (CheckGround) and move it under the player. Remember to give it Gizmos to see it easily
    //--Drag and drop CheckGround in groundCheck
    //--Also give all the ground objects layer named Ground and choose that in Sorting Layer. That will be used to determine what is ground

    //--Reference to rigidbody2D
    public new Rigidbody2D rigidbody;
    //--Force applied to Rigidbody to make player jump
    public float jumpForce = 1000;

    //--Check if player is on the ground
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

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
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //--Checking if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
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
                //--Then apply the force to Rigidbody to make player jump
                rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
                //--when you are in the air and jump again you will lose your extra jump
                extraJumps--;
        }
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && extraJumps == 0 && isGrounded == true)
        {
            //--if we are on the ground and jump
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Force);
        }
    }

    //--Game Over happens here if player hits object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //--If the object has GameOver tag, player loses
        if (collision.collider.CompareTag("GameOver"))
        {
            Destroy(this.gameObject);
            GameController_JumpingGame.isGameOver = true;   //--Show Game Over screen. isGameOver is in GameController_JumpingGame script
            GameController_JumpingGame.isPaused = true;     //--Game is paused
            gCJumpingGame.pauseGame();                      //--Call the pause to happen
        }
    }
}
