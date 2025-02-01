using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // Player 1 movement (WASD)
        float moveX = Input.GetAxisRaw("Horizontal"); // A and D keys
        float moveY = Input.GetAxisRaw("Vertical");   // W and S keys
        Vector2 movement = new Vector2(moveX, moveY).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}