using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab; // Assign PurpleProjectile.prefab in Inspector
    public float cooldown = 1f; // Time between shots
    private Rigidbody2D rb;

    private float lastShotTime;
    private Vector2 lastMovementDirection = Vector2.up; // Default direction

    public Animator anim;

    public int facingDirection = 1;

    private bool isKnockedback;

    void Update()
    {

        if (isKnockedback == false)
        {
            // Movement
            float moveX = Input.GetAxisRaw("HorizontalArrow"); // Use arrow keys for Player 2
            float moveY = Input.GetAxisRaw("VerticalArrow");
            Vector2 movement = new Vector2(moveX, moveY).normalized;

            if (movement != Vector2.zero) // Update last movement direction if moving
            {
                lastMovementDirection = movement;
            }

            transform.Translate(movement * moveSpeed * Time.deltaTime);

            // Shooting
            if (Input.GetKeyDown(KeyCode.RightShift) && Time.time > lastShotTime + cooldown) // Use RightControl key for Player 2
            {
                Shoot(lastMovementDirection); // Shoot in the last movement direction
                lastShotTime = Time.time;
            }

            if(moveX > 0 && transform.localScale.x > 0 || moveX < 0 && transform.localScale.x < 0)
            {
                Flip();
            }
        anim.SetFloat("horizontal", Mathf.Abs(moveX));
        anim.SetFloat("vertical", Mathf.Abs(moveY));
        }
    }

    public void Knockback(Transform enemy)
    {
        isKnockedback = true;
        Vector2 direction = transform.position - enemy.position;
        rb.linearVelocity = direction;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
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