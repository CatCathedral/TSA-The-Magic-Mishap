using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject projectilePrefab; // Assign GreenProjectile.prefab in Inspector
    public float cooldown = 1f; // Time between shots
    private Rigidbody2D rb;
    public CoinManager cm;
    private float lastShotTime;
    private Vector2 lastMovementDirection = Vector2.up; // Default direction

    public Animator anim;

    public int facingDirection = 1;

    private bool isKnockedback;

    public Player_Combat playerCombat;



    void Update()
    {

        if (Input.GetButtonDown("GirlAttack"))
        {
            playerCombat.Attack();
        }

        if (isKnockedback == false)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Magic Globe"))
        {
            Destroy(other.gameObject);
            cm.coinCount++; 
        }        
    }
}