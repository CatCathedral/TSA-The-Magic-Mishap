using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth; // Maximum health of the enemy
    public int currentHealth; // Current health of the enemy


    void Start()
    {
        currentHealth = maxHealth; // Set current health to max health at the start
    }

    // Function to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by the damage amount

        // Check if the enemy is dead
        if (currentHealth <= 0)
        {
            Defeat();
        }
    }

    // Function to handle enemy defeat
    private void Defeat()
    {
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}