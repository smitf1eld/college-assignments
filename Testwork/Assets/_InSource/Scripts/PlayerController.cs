using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float flapForce = 8f;
    private Rigidbody2D rb;
    private bool isGameOver = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetMouseButtonDown(0))
        {
            if (!rb.simulated) rb.simulated = true;
            Flap();
        }
    }

    void Flap()
    {
        rb.linearVelocity = new Vector2(0, flapForce);
    }

    public void GameOver()
    {
        isGameOver = true;
        rb.linearVelocity = Vector2.zero;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }
}