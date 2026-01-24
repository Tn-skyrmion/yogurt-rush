using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Switch finalSwitch;
    private BoxCollider2D col;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        col.enabled = !finalSwitch.pressed;
        GetComponent<SpriteRenderer>().enabled = !finalSwitch.pressed;
    }
}
