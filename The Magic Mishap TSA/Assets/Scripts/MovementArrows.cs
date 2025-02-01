using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementArrows : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    

    // Update is called once per frame
    void Update()
    {
         float horizontal = Input.GetAxis("Horizontal");
         float vertical = Input.GetAxis("Vertical");;
         rb.linearVelocity = new Vector2(horizontal, vertical);
        
         if (Input.GetKeyDown(KeyCode.DownArrow))
         {
            horizontal = -1;
         }

         if (Input.GetKeyDown(KeyCode.UpArrow))
         {
            horizontal = 1;
         }

         if (Input.GetKeyDown(KeyCode.LeftArrow))
         {
            vertical = -1;
         }

         if (Input.GetKeyDown(KeyCode.RightArrow))
         {
            vertical = 1;
         }

         if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
         {
            vertical = 0;
         }

         if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.UpArrow))
         {
            horizontal = 0;
         }
    }
}
