using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public Vector2 direction;
    public float lifetime = 3f; // Time in seconds before the projectile is destroyed

    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time; // Record the time when the projectile is spawned
    }

    void Update()
    {
        // Move the projectile in the specified direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Destroy the projectile if it exceeds its lifetime
        if (Time.time > spawnTime + lifetime)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collision (e.g., destroy the projectile or deal damage)
        if (!collision.CompareTag("Player")) // Ignore player collisions
        {
            Destroy(gameObject);
        }
    }
}