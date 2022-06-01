using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterController controller;

    public float forwardSpeed;
    public float gravity;
    public float jumpVelocity;
    Vector3 velocity;
    public int health;
    private bool onScreen = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        MoveCharacter();
    }

    void MoveCharacter(){

        velocity = new Vector3(0, 0, forwardSpeed);

        if (!controller.isGrounded)
        {
            jumpVelocity -= gravity; 
        }
        velocity.y = jumpVelocity;
        controller.Move(velocity);
    }

        void OnBecameVisible()
        {
        onScreen = true;    
        }

    void OnBecameInvisible()
    {
        if(onScreen)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int power)
    {
        health -= power;
        Debug.Log("ouch");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
