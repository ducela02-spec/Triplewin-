using UnityEngine;

public class SwipeBallController : MonoBehaviour
{
    public Rigidbody ball;
    public float forceMultiplier = 8f;
    public float maxSwipeDistance = 500f;

    private Vector2 swipeStart;
    private bool swiping;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
                swiping = true;
            }

            if (touch.phase == TouchPhase.Ended && swiping)
            {
                Vector2 swipeEnd = touch.position;
                Vector2 swipe = swipeEnd - swipeStart;

                swiping = false;

                if (swipe.magnitude > 30f)
                {
                    ShootBall(swipe);
                }
            }
        }
    }

    void ShootBall(Vector2 swipe)
    {
        swipe = Vector2.ClampMagnitude(swipe, maxSwipeDistance);

        Vector3 direction = new Vector3(
            swipe.x,
            swipe.y * 0.7f,
            1f
        ).normalized;

        ball.AddForce(direction * forceMultiplier, ForceMode.Impulse);
    }
}
