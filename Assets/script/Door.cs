using UnityEngine;

public class Door : MonoBehaviour
{
    public Switch switchA;
    public Switch switchB;
    public bool open = false;

    private BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        open = switchA.pressed || switchB.pressed;
        col.enabled = !open;
        GetComponent<SpriteRenderer>().enabled = !open;
    }
}
