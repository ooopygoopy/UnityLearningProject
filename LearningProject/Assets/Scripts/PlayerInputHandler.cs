using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Main Player Input Handler Script
public class PlayerInputHandler : MonoBehaviour
{

    [Header("Input Action Asset")]
    //References the PlayerControls control scheme
    [SerializeField] private InputActionAsset playerControls;

    [Header("Action Map Name References")]
    //References the control action map named "Player" in the PlayerControls control Scheme
    [SerializeField] private string actionMapName = "Player";

    [Header("Action Name References")]
    //References the actions in the "Player" control action map located in the PlayerControl scheme
    [SerializeField] private string move = "Move";
    [SerializeField] private string look = "Look";
    [SerializeField] private string jump = "Jump";
    [SerializeField] private string sprint = "Sprint";

    //References the Input Actions found in the Control Scheme
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;
    private InputAction sprintAction;

    //Gets the values of each of the inputs to see if they have been pressed
    public Vector2 MoveInput { get; private set;  }
    public Vector2 Look { get; private set;  }
    public bool JumpTriggered { get; private set;  }
    public float SprintValue { get; private set;  }


}
