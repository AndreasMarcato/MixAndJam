using UnityEngine;

public class Paddle : MonoBehaviour
{   
    public float speed = 1.5f;
    protected Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
}
