using UnityEngine;

public class TopWall : Logic
{
    void OnTriggerEnter2D()
    {
        //Debug.Log(score);
        //Debug.Log("Top Triggered");
        score++;
        //Debug.Log("+1 Score");
        //Debug.Log(score + "score's value now");
        Respawn();
    }
}
