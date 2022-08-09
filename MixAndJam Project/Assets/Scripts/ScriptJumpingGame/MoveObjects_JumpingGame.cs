using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects_JumpingGame : MonoBehaviour
{
    //-------THIS IS FOR MOVING AND DESTROYING 3D OBJECTS--------
    private Rigidbody rb3D;

    private void Awake()
    {
        //--Get the rigidbody
        rb3D = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //--Moves the 3D object
        rb3D.velocity = new Vector3(-2, 0f, 0f);
    }



    //--On collision destroy this object
    private void OnCollisionEnter(Collision collision)
    {
              if (collision.collider.CompareTag("Destroy"))
              {
                  Destroy(this.gameObject);
              }
    }
}
