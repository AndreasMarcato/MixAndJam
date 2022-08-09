using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Hub : MonoBehaviour
{
    Vector2 startTouchPosition;
    Vector2 currentTouchPosition;
    Vector2 dPosition;
   // [SerializeField] GameObject swipeStartTrack = null;  //an Empty GameObject to use as reference
    [SerializeField] GameObject player = null;           //the player GameObject as reference
    [SerializeField] int speed = 5;                     //moving speed
    [SerializeField] bool isMenu = false;                //check if it's the HUB scene

    private void Start()
    {
        isMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        //check HUB scene
        if (isMenu)
            MovePlayer();
    }

    //checks the movement system with touches
    void MovePlayer()
    {
        foreach (Touch touch in Input.touches)
        {
            //if player touches the screen
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
               // swipeStartTrack.transform.position = touch.position; //sets the start position of the touch; useful if we want to add a sprite for the control visuals
               // Debug.Log("Touch Phase Began");

            }
            else if (touch.phase == TouchPhase.Moved)               //moving the finger on the screen
            {
                currentTouchPosition = touch.position;
                ProcessMovement();
                Debug.Log("Touch Ended");

            }
        }

        //mouse touch simulation
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
           // swipeStartTrack.transform.position = Input.mousePosition;
            Debug.Log("Touch Phase Began");
        }
        else if (Input.GetMouseButton(0))
        {
            currentTouchPosition = Input.mousePosition;
            ProcessMovement();
        }
    }

    void ProcessMovement()
    {
        //distance between start and current finger's position on screen
        float distance = Vector2.Distance(startTouchPosition, currentTouchPosition);

        if (currentTouchPosition.x == startTouchPosition.x)
        {
            //nothing happens
            //Debug.Log("same position");
        }
        else if (currentTouchPosition.x > startTouchPosition.x)
        {
            //moves right
            dPosition = (Vector2.right * speed);
            player.transform.Translate(dPosition * Time.deltaTime);
            //Debug.Log("move right");
        }
        else
        {
            //moves left
            dPosition = (Vector2.left * speed);
            player.transform.Translate(dPosition * Time.deltaTime);
            //Debug.Log("move left");
        }
    }
}
