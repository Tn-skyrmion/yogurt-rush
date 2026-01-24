using UnityEngine;

public class StickyFriction : MonoBehaviour
{
    public float groundFriction = 0.85f;
    public float airFriction = 0.75f;

    private Rigidbody2D rb;
    private PlayerController pc;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        bool grounded = pc != null && Physics2D.OverlapCircle(pc.groundCheck.position, 0.1f, pc.groundLayer);

        if (grounded)
            rb.velocity = new Vector2(rb.velocity.x * groundFriction, rb.velocity.y);
        else
            rb.velocity = new Vector2(rb.velocity.x * airFriction, rb.velocity.y);
    }
}
