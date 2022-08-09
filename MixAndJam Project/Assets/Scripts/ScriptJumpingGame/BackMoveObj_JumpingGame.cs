using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMoveObj_JumpingGame : MonoBehaviour
{
    //-------THIS IS FOR MOVING AND DESTROYING 2D OBJECTS--------
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        //--Get rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //--Moves the 2D object
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
