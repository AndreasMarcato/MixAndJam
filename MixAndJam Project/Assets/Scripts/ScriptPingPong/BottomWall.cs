using UnityEngine;

public class BottomWall : Logic
{

    void OnTriggerEnter2D()
    {
        Debug.Log("Bottom Triggered");
        TakeDamage();
        Respawn();
    }
}
