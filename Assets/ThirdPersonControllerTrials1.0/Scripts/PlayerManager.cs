using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    public PlayerData playerData;
    [HideInInspector]
    public AnimatorManager animatorManager;
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;
    [Space]
    public bool isInteracting;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        cameraManager.HandleAllCameraMovement();

        isInteracting = animatorManager.animator.GetBool("IsInteracting");
        playerLocomotion.isJumping = animatorManager.animator.GetBool("IsJumping");
        animatorManager.animator.SetBool("IsGrounded", playerLocomotion.isGrounded);
    }
    public void DiscardPlayerData()
    {
        playerData = null;
    }
}
