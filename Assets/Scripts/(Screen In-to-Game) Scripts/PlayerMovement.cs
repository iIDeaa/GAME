using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);
        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastX", moveInput.x);
            animator.SetFloat("LastY", moveInput.y);
        }
        
        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InX", moveInput.x);
        animator.SetFloat("InY", moveInput.y);
    }
}
