using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartingForce();
    }

    public void AddStartingForce()
    {        
        Vector2 direction = Vector2.down;
        rigidbody.AddForce(direction * this.speed);
    }
}
