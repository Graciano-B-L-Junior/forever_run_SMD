using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    public float forwardSpeed;
    public float sideSpeed;
    public float jumpHeight;
    public float jumpVelocity;
    public float gravity;

    private float direction;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        direction = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(direction * sideSpeed, 0, forwardSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space)){
                jumpVelocity = jumpHeight;
            }
        } else {
            jumpVelocity -= gravity; 
        }

        velocity.y = jumpVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}