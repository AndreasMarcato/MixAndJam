using UnityEngine;

public class Spaceship : Logic
{
    void OnTriggerEnter2D()
    {
        //Debug.Log(score);
        //Debug.Log("Spacheship Triggered");
        ship.GetComponent<Animator>().SetTrigger("Hit");
        //Debug.Log("Hit");
    }
}
