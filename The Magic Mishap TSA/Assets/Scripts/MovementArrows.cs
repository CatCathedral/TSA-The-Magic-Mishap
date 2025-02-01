using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Player 2 movement (Arrow keys)
        float moveX = Input.GetAxisRaw("HorizontalArrow"); // Left and Right arrows
        float moveY = Input.GetAxisRaw("VerticalArrow");   // Up and Down arrows
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}