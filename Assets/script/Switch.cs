using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool pressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            pressed = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            pressed = false;
    }
}
