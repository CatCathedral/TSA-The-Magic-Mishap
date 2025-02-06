using UnityEngine;
using System.Collections.Generic;


public class EnemyMovement : MonoBehaviour
{
    public float speed; // Speed at which the enemy moves
    private bool isChasing;
    private Rigidbody2D rb;
    private List<Transform> players; // List to store all players
    private Transform targetPlayer; // Current target player


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        players = new List<Transform>(); // Initialize the list of players
    }


    void Update()
    {
        if (isChasing && targetPlayer != null)
        {
            // Move towards the target player
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            rb.linearVelocity = direction * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Stop moving if not chasing
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Add the player to the list if not already present
            if (!players.Contains(collision.transform))
            {
                players.Add(collision.transform);
            }


            // Start chasing and set the target player
            isChasing = true;
            targetPlayer = GetClosestPlayer();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Remove the player from the list
            players.Remove(collision.transform);


            // If no players are left, stop chasing
            if (players.Count == 0)
            {
                isChasing = false;
                targetPlayer = null;
            }
            else
            {
                // Switch to the next closest player
                targetPlayer = GetClosestPlayer();
            }
        }
    }


    private Transform GetClosestPlayer()
    {
        Transform closestPlayer = null;
        float closestDistance = Mathf.Infinity;


        // Find the closest player in the list
        foreach (Transform player in players)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player;
            }
        }


        return closestPlayer;
    }
}
