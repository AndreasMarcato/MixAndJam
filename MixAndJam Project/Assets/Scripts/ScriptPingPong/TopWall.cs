using UnityEngine;

public class TopWall : Logic
{
    void OnTriggerEnter2D()
    {
        Debug.Log("Top Triggered");
        score += 1;
        Debug.Log("+1 Score");
        Respawn();
    }
}
