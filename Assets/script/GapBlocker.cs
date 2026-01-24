using UnityEngine;

public class GapBlocker : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        var pc = other.GetComponent<PlayerController>();
        if (pc != null && pc.GetState() == "hard")
        {
            // ÈÃÓ²Ì¬¿¨×¡
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
