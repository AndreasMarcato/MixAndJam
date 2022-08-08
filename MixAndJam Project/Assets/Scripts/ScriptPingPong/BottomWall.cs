using UnityEngine;

public class BottomWall : Logic
{

    void OnTriggerEnter2D()
    {
        ReSpawn();
        TakeDamage();
    }
    public void TakeDamage(){
        this.health -= 1;
    }
}
