using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //puts heading above variable ins inspector
    [Header("Player Component References")]
    //keeps rb private but exposes in inspector
    [SerializeField] Rigidbody2D rb;

    //Player settings declaration
    [Header("Player Settings")]
    [SerializeField] float speed;
    [SerializeField] float jumpingPower;

    //ground check variables
    [Header("Grounding")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    [Header("Ground Check Radius")]
    [SerializeField] float groundCheckRadius;

    //for horizontal control
    private float horizontal;

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    #region PLAYER_CONTROLS
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;

    }
    #endregion

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }
    }

    private bool IsGrounded()
    {
        //checks is the ground check child is overlaping with any object in the ground layer
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

}
