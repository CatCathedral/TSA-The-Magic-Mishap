using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWASD : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
         float horizontal = Input.GetAxis("Horizontal");
         float vertical = Input.GetAxis("Vertical");;
         rb.linearVelocity = new Vector3(horizontal, vertical);
         if (Input.GetKeyDown(KeyCode.S))
         {
            vertical = -1;
         }

         if (Input.GetKeyDown(KeyCode.W))
         {
            vertical = 1;
         }

         if (Input.GetKeyDown(KeyCode.A))
         {
            horizontal = -1;
         }

         if (Input.GetKeyDown(KeyCode.D))
         {
            horizontal = 1;
         }

         if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
         {
            horizontal = 0;
         }

         if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
         {
            vertical = 0;
         }
    }
}
