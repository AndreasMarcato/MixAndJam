using UnityEngine;

public class Shield : Paddle
{
    private Vector2 direction;
    private Touch touch;

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
            rigidbody.AddForce(direction * this.speed);
        }
    }
}
