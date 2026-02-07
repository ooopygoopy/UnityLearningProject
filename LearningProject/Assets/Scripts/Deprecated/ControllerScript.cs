using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    //Sets the movement speed and sprint multiplier values
    [Header("Movement Speeds")]
    [SerializeField] private float walkSpeed = 3.0f;
    [SerializeField] private float sprintMultiplier = 2.0f;

    [Header("Jump Params")]
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float gravityForce = 9.81f;


    //locates the character controller to move the character
    private CharacterController characterController;
    //private Rigidbody2D rb;

    //locates the input handler to handle input
    private PlayerInputHandler inputHandler;

    private Vector2 currentMovement;

    //runs on startup
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody2D>();

        inputHandler = PlayerInputHandler.Instance;
    }

    //runs every frame
    private void Update()
    {
        HandleMovement();
    }

    //function movement handler
    void HandleMovement()
    {
        //calculate movement speed and included sprint if sprinting
        float speed = walkSpeed * (inputHandler.SprintValue > 0 ? sprintMultiplier : 1f);

        Vector2 inputDirection = new Vector2(inputHandler.MoveInput.x, 0f);
        Vector2 worldDirection = transform.TransformDirection(inputDirection);
        worldDirection.Normalize();

        currentMovement.x = worldDirection.x * speed;
        currentMovement.y = worldDirection.y * speed;


        HandleJumping();

        //moves character with respect to time
        characterController.Move(currentMovement * Time.deltaTime);
        //rb.MovePosition(currentMovement * Time.deltaTime);

    }
    void HandleJumping()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = -0.5f;
            if (inputHandler.JumpTriggered)
            {
                currentMovement.y = jumpForce;
            }
        }
        else
        {
            currentMovement.y -= gravityForce * Time.deltaTime;
        }
    }
}
