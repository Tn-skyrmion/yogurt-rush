using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accel = 0.9f;
    public float maxSpeed = 8f;
    public float hardSpeed = 5f;
    public float jumpForce = 13f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private string state = "soft"; // soft / hard / split

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 地面检测
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // 控制
        float move = 0;
        if (Input.GetKey(KeyCode.A)) move = -1;
        if (Input.GetKey(KeyCode.D)) move = 1;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x + move * accel, -maxSpeed, maxSpeed), rb.velocity.y);

        // 状态判定（非分裂）
        if (state != "split")
        {
            state = Mathf.Abs(rb.velocity.x) > hardSpeed ? "hard" : "soft";
        }

        // 跳跃（仅硬态）
        if (Input.GetKeyDown(KeyCode.Space) && state == "hard" && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public string GetState()
    {
        return state;
    }

    public void SetState(string s)
    {
        state = s;
    }
}
