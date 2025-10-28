using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float initialSpeed = 8f;
    public float speedIncrease = 0.5f;
    public float goalX = 9.5f;
    public float maxBounceAngle = 60f; // degrees

    void Reset()
    {
        if (rb == null) rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        float angle = Random.Range(-30f, 30f);
        float dir = Random.value < 0.5f ? -1f : 1f;
        Vector2 dirVec = new Vector2(dir * Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = dirVec * initialSpeed;
    }

    void FixedUpdate()
    {
        // Check for scoring
        if (transform.position.x > goalX)
        {
            if (GameManager.Instance != null) GameManager.Instance.ScoreLeft();
        }
        else if (transform.position.x < -goalX)
        {
            if (GameManager.Instance != null) GameManager.Instance.ScoreRight();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Paddle"))
        {
            // Preserve the ball's momentum but bias the rebound angle based on where the paddle was hit.
            Vector2 incoming = rb.linearVelocity;

            // Determine normalized hit position on paddle (-1 bottom ..0 center ..1 top)
            float yDiff = transform.position.y - col.transform.position.y;
            float halfHeight = 0.5f;
            if (col.collider != null)
            {
                halfHeight = col.collider.bounds.extents.y;
                if (halfHeight <= 0f) halfHeight = 0.5f;
            }
            float normalizedHit = Mathf.Clamp(yDiff / halfHeight, -1f, 1f);

            // Compute bounce angle based on hit position
            float bounceAngleRad = normalizedHit * maxBounceAngle * Mathf.Deg2Rad;

            // Determine horizontal direction to send the ball (away from the paddle)
            // Use relative positions to ensure correct direction for both left and right paddles
            float dirX = Mathf.Sign(transform.position.x - col.transform.position.x);

            // Build the new direction using the bounce angle (x = cos, y = sin)
            Vector2 newDir = new Vector2(dirX * Mathf.Cos(bounceAngleRad), Mathf.Sin(bounceAngleRad)).normalized;

            // Preserve speed (plus optional increase)
            float speed = incoming.magnitude + speedIncrease;
            rb.linearVelocity = newDir * speed;
        }
        else
        {
            // When hitting top/bottom walls, let physics handle it or reflect y
            // Do nothing special here
        }
    }
}
