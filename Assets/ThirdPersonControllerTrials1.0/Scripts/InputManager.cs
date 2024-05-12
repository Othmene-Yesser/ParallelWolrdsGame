using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    PlayerLocomotion playerLocomotion;
    AnimatorManager animatorManager;
    EscapeMenuManager ui;

    public Vector2 movementInput;
    public Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool b_Input; //sprinting
    public bool jump_Input;
    public bool b_Attack;
    public bool b_Interact;
    public bool b_Escape;

    private void Awake()
    {
        animatorManager= GetComponent<AnimatorManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        ui = GetComponent<EscapeMenuManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            
            //when we hit the keys WASD we are going to record the movement to movementInput
            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            //read values when mouse moves or right joystick moves
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            //read if we clicked the sprinting button "B"
            playerControls.PlayerActions.B.performed += i => b_Input = true;
            playerControls.PlayerActions.B.canceled += i => b_Input = false;
            //read if we clicked space for the jump
            playerControls.PlayerActions.Jump.performed += i => jump_Input = true;
            //read if we clicked left mouse button for the attack
            playerControls.PlayerActions.SwordAttack.performed += i => b_Attack = true;
            //read if we clicked the button e to interact
            playerControls.PlayerActions.Interact.performed += i => b_Interact = true;
            playerControls.PlayerActions.Interact.canceled += i => b_Interact = false;
            //read if we clicked escape
            playerControls.PlayerActions.Escape.performed += i => b_Escape = true;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpingInput();
        //handle action input
        HandleAttackingInput();
        HandleUi();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));  //we do Mathf.abs because we use 0 to 1 values on the blend tree for walking forward
        animatorManager.UpdateAnimatorValues(0, moveAmount, playerLocomotion.isSprinting);
    }

    private void HandleSprintingInput()
    {
        if (b_Input && moveAmount > 0.5f)
        {
            playerLocomotion.isSprinting = true;
        }
        else
        {
            playerLocomotion.isSprinting = false;
        }
    }

    private void HandleJumpingInput()
    {
        if (jump_Input)
        {
            jump_Input = false;
            //! Jump
            playerLocomotion.HandleJumping();
        }
    }
    private void HandleAttackingInput()
    {
        if (b_Attack)
        {
            b_Attack = false;
            //! Attack
            playerLocomotion.HandleAttacking();
        }
    }
    private void HandleUi()
    {
        if (b_Escape)
        {
            b_Escape = false;
            //! Enable Escape Menu
            ui.EscapeMenu();
        }
    }
}
