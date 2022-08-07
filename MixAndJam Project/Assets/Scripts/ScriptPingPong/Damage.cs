using UnityEngine;

public class Damage : MonoBehaviour
{
    BoxCollider2D box;
    public int health; 
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    void OnTriggerEnter2D(Collider2D col){
        TakeDamage();
    }
    public void TakeDamage(){
        health -= 1;
    }
}
