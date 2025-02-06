using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public float knockbackForce = 10f; // The force of the knockback
    public float knockbackDuration = 0.2f; // How long the knockback lasts

    private Rigidbody2D rb;
    private bool isKnockedBack = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Calculate knockback direction
            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;

            // Apply knockback
            Knockback(knockbackDirection);
        }
    }

    private void Knockback(Vector2 direction)
    {
        if (!isKnockedBack)
        {
            isKnockedBack = true;

            // Apply force to the player
            rb.linearVelocity = Vector2.zero; // Reset velocity
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

            // Start coroutine to stop knockback after duration
            StartCoroutine(StopKnockback());
        }
    }

    private System.Collections.IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(knockbackDuration);

        // Stop the knockback
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}