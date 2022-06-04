using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
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
        animator = GetComponent<Animator>();
        animator.SetBool("Die",false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.gameOver == false)
        {
            MovePlayer();
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {

            GameManager.gameOver = true;
            animator.SetBool("Die",true);
        }
    }
    void MovePlayer()
    {
        direction = Input.GetAxisRaw("Horizontal");
        Vector3 velocity = new Vector3(direction * sideSpeed, 0, forwardSpeed);

        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpVelocity = jumpHeight;
            }
        }
        else
        {
            jumpVelocity -= gravity;
        }

        velocity.y = jumpVelocity;
        controller.Move(velocity * Time.deltaTime);
    }
}