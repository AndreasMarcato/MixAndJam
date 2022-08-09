using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float speed = 100.0f;
    private Rigidbody2D _rigidbody;
    GameObject bounce, shoot;

    private void Awake()
    {
        bounce = GameObject.Find("Bounce");
        shoot = GameObject.Find("ShootSound");
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AddStartingForce();
    }

    public void AddStartingForce()
    {
        shoot.GetComponent<AudioSource>().Play(0);
        Vector2 direction = Vector2.down;
        _rigidbody.AddForce(direction * this.speed);
    }
    void OnCollisionEnter2D()
    {
        GetComponent<SpriteRenderer>().flipX = (GetComponent<SpriteRenderer>().flipX == false) ? true : false;
        bounce.GetComponent<AudioSource>().Play(0);
    }
}
