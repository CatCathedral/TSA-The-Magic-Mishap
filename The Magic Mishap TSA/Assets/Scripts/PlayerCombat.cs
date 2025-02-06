using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    public Animator anim;
    public float cooldown = 2f;
    public int attackDamage = 20; 

    private float timer;
    private bool canDamage = false; 

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (timer <= 0)
        {
            anim.SetBool("isAttacking", true);
            timer = cooldown;
        }
    }

    public void FinishAttacking()
    {
        anim.SetBool("isAttacking", false);
    }

    public void EnableAnimationDamage()
    {
        canDamage = true;
    }

    public void DisableAnimationDamage()
    {
        canDamage = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage && collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(attackDamage);
                canDamage = false;
            }
        }
    }
}
