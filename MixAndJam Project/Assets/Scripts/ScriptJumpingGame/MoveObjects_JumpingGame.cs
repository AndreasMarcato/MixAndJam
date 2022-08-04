using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects_JumpingGame : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        //--Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //--Moves the object
        rb.velocity = new Vector2(-2f, 0f);
    }

    //--Destroy this object if hits the object with tag "Destroy"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Destroy"))
        {
            Destroy(this.gameObject);
        }
    }
}
