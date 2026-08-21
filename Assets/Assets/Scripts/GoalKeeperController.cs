using UnityEngine;

public class GoalkeeperController : MonoBehaviour
{
    [Header("Goalkeeper Movement")]
    public float diveDistance = 1.8f;
    public float diveSpeed = 8f;
    public float returnSpeed = 5f;

    private Vector2 swipeStart;
    private bool isMoving;
    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        HandleSwipe();

        if (!isMoving)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                startingPosition,
                returnSpeed * Time.deltaTime
            );
        }
    }

    void HandleSwipe()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                swipeStart = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Vector2 swipe = touch.position - swipeStart;

                if (swipe.magnitude < 40f)
                    return;

                Vector2 direction = swipe.normalized;

                Vector3 target = startingPosition;

                target.x += direction.x * diveDistance;
                target.y += direction.y * diveDistance;

                StopAllCoroutines();
                StartCoroutine(MoveGoalkeeper(target));
            }
        }
    }

    System.Collections.IEnumerator MoveGoalkeeper(Vector3 target)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                diveSpeed * Time.deltaTime
            );

            yield return null;
        }

        yield return new WaitForSeconds(0.35f);

        isMoving = false;
    }
}
