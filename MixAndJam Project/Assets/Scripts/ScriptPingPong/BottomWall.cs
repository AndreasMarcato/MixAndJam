using UnityEngine;

public class BottomWall : Logic
{

    void OnTriggerEnter2D()
    {
        //Debug.Log("Bottom Triggered");
        //Debug.Log(score);
        TakeDamage();
        //Debug.Log(score);
        Respawn();
    }
}
