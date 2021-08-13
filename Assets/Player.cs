


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity;
    public Vector2 velocity;
    public float jumpVelocity;

    public float groundHeight = 10;
    public bool isGrounded = false;

    void Update() 
    {
        if(isGrounded)
        {
            Debug.Log("check");
                if(Input.GetKeyDown("space"))
                {
                    isGrounded = false;
                    velocity.y = jumpVelocity;
                    Debug.Log("test");
                }
        }
    }

    void FixedUpdate() 
    {
        Vector2 pos = transform.position;

        if(!isGrounded)  
        {
            pos.y += velocity.y * Time.fixedDeltaTime;
            velocity.y += gravity * Time.fixedDeltaTime;

            if( pos.y <= groundHeight)
            {
                pos.y = groundHeight;
                isGrounded = true;
            }
        } 

         transform.position = pos;
    }
}
