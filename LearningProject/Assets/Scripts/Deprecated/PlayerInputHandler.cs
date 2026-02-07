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
    //Use getters/setters to make controls more protected
    public Vector2 MoveInput { get; private set;  }
    public Vector2 LookInput { get; private set;  }
    public bool JumpTriggered { get; private set;  }
    public float SprintValue { get; private set;  }

    //Use script as instance/singleton to allow reference from other scripts
    public static PlayerInputHandler Instance { get; private set; }

    private void Awake()
    {

        // makes sure there are no duplicates of this script
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        //allows reference to actions in order to use them
        moveAction = playerControls.FindActionMap(actionMapName).FindAction(move);
        lookAction = playerControls.FindActionMap(actionMapName).FindAction(look);
        jumpAction = playerControls.FindActionMap(actionMapName).FindAction(jump);
        sprintAction = playerControls.FindActionMap(actionMapName).FindAction(sprint);
        //calls the register input actions function
        RegisterInputActions();
    }

    //registers actions
    void RegisterInputActions()
    {
        //if the move actions happes check the value of move input vector
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        //if the move action canceld set the value of move input vector zero
        moveAction.canceled += context => MoveInput = Vector2.zero;

        lookAction.performed += context => LookInput = context.ReadValue<Vector2>();
        lookAction.canceled += context => LookInput = Vector2.zero;

        jumpAction.performed += context => JumpTriggered = true;
        jumpAction.canceled += context => JumpTriggered = false;

        sprintAction.performed += context => SprintValue = context.ReadValue<float>();
        sprintAction.canceled += context => SprintValue = 0f;


    }

    //Allows to enable events when they are needed
    private void OnEnable()
    {
        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
        sprintAction.Enable();
    }

    //Allows to disable events when they are needed
    //ex used when the game or script ends or scene change
    private void OnDisable()
    {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();
        sprintAction.Disable();
    }


}
