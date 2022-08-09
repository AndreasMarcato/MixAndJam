using UnityEngine;
using System.Threading;

public class Spaceship : Logic
{
    void OnTriggerEnter2D()
    {
        Debug.Log("Spacheship Triggered");
        ship.GetComponent<Animator>().SetTrigger("Hit");
        Debug.Log("Hit");
    }
}
