using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class EnemyMovement : MonoBehaviour
{
  
  public float speed;
  private Rigidbody2D rb;
  private int facingDirection = -1;
  private Transform player;
  private Animator anim;
  private EnemyState enemyState;




  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
      rb = GetComponent<Rigidbody2D>();
      anim = GetComponent<Animator>();
      ChangeState(EnemyState.Idle);
  }


   void Flip()
   {
       facingDirection *= -1;
       transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
   }


  // Update is called once per frame
  void Update()
  {
      if (enemyState == EnemyState.Chasing)
      {
           if (player.position.x > transform.position.x && facingDirection == -1 || player.position.x < transform.position.x && facingDirection == 1)
           {
               Flip();
           }
          Vector2 direction = (player.position - transform.position).normalized;
          rb.linearVelocity = direction * speed;
      }
  }




  private void OnTriggerEnter2D(Collider2D collision)
  {
      if (collision.gameObject.tag == "Player")
      {
          if (player == null)
          {
              player = collision.transform;
          }
          ChangeState(EnemyState.Chasing);
      }
  }




  private void OnTriggerExit2D(Collider2D collision)
  {
      if (collision.gameObject.tag == "Player")
      {
          rb.linearVelocity = Vector2.zero;
          ChangeState(EnemyState.Idle);
      }
  }


   void ChangeState(EnemyState newState)
   {
       // Exits animation
       if(enemyState == EnemyState.Idle)
           anim.SetBool("isIdle", false);
       else if (enemyState == EnemyState.Chasing)
           anim.SetBool("isChasing", false);


       // Updates the current state
       enemyState = newState;


       // Update to new animation
       if(enemyState == EnemyState.Idle)
           anim.SetBool("isIdle", true);
       else if (enemyState == EnemyState.Chasing)
           anim.SetBool("isChasing", true);
   }


}


public enum EnemyState
{
   Idle,
   Chasing,
}
