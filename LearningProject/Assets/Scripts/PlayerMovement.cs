using System.IO;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerMovement : MonoBehaviour
{
    InputAction actionMove;
    InputAction actionJump;
    // Update is called once per frame

    private void Start()
    {
        //finds the references to the Move and Jump actions in the InputSystem lib
        actionMove = InputSystem.actions.FindAction("Move");
        actionJump = InputSystem.actions.FindAction("Jump");
    }
    void Update()
    {
        //Reads move actions value which is the 2D vector
        Vector2 moveValue = actionMove.ReadValue<Vector2>();
        //Movement code below
        if (actionMove.IsPressed())
        {

        }

        if (actionJump.IsPressed())
        {

        }

    }
}
