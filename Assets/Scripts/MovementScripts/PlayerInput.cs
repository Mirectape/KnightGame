using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void SetDefaultValues() => playerMovement = GetComponent<PlayerMovement>();
    
    private void InputConditions()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    private void Update()
    {
        if(Character.Instance.isActive)
        {
            InputConditions();
        }
    }
}
