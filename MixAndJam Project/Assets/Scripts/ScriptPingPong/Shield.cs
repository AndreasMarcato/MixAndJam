using UnityEngine;

public class Shield : MonoBehaviour
{
    private Vector2 direction;
    private Touch touch;
    public float speed = 1.5f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch(0);
            direction = touch.deltaPosition;
        } else {
            direction = Vector2.zero;
        }
    }
    private void FixedUpdate()
    {
        if (touch.phase == TouchPhase.Moved) {
            _rigidbody.AddForce(direction * this.speed);
        }
    }
}
