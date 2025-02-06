using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int attackDamage = 20; // Damage dealt by the player's attack

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider is an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component and deal damage
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);

                // Optional: Add knockback to the enemy
                //ApplyKnockback(collision.transform);
            }
        }
    }
    /*
    private void ApplyKnockback(Transform enemyTransform)
    {
        // Calculate knockback direction based on player position
        
        Vector2 knockbackDirection = (enemyTransform.position - transform.position).normalized;

        // Apply knockback force to the enemy
        Rigidbody2D enemyRb = enemyTransform.GetComponent<Rigidbody2D>();
        if (enemyRb != null)
        {
            enemyRb.linearVelocity = Vector2.zero; // Reset velocity
            enemyRb.AddForce(knockbackDirection * 5f, ForceMode2D.Impulse); // Adjust force as needed
        }
         
    }
    */
}