using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab; // Assign GreenProjectile.prefab in Inspector
    public float cooldown = 1f; // Time between shots

    private float lastShotTime;
    private Vector2 lastMovementDirection = Vector2.up; // Default direction

    void Update()
    {
        // Movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        if (movement != Vector2.zero) // Update last movement direction if moving
        {
            lastMovementDirection = movement;
        }

        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Shooting
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + cooldown)
        {
            Shoot(lastMovementDirection); // Shoot in the direction of movement
            lastShotTime = Time.time;
        }
    }

    void Shoot(Vector2 direction)
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile prefab is not assigned!");
            return;
        }

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.direction = direction;
        }
    }
}