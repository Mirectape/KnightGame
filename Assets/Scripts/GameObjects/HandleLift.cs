using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLift : MonoBehaviour
{
    [SerializeField, Header("An elevator we want to operate")] private SliderJoint2D elevator;
    [SerializeField, Header("Set the area where the player can operate the handle")] private CheckIfAroundHandle conditions;
    [SerializeField, Header("Ratchet crank sound")] private AudioSource crankSound;

    private Animator handle;
    private bool elevatorIsActivated;
    private void SetDefaultValues()

    {
        handle = GetComponent<Animator>();
        elevatorIsActivated = false;
    }

    private void Awake()
    {
        SetDefaultValues();
    }

    /// <summary>
    /// On handle pulled
    /// </summary>
    private void ElevatorActivate()
    {
        if(crankSound != null) crankSound.Play();
        handle.SetBool("e_IsPressed", true);
        elevatorIsActivated = true;
    }
    
    /// <summary>
    /// On handle pulled back
    /// </summary>
    private void ElevatorDeactivate()
    {
        handle.SetBool("e_IsPressed", false);
        elevatorIsActivated = false;
    }

    /// <summary>
    /// Play at the end of the animation ElevatorActivate()
    /// </summary>
    private void MotorActivate()
    {
        elevator.useMotor = true;
        
    }

    /// <summary>
    /// Play at the end of the animation ElevatorDeactivate()
    /// </summary>
    private void MotorDeactivate()
    {
        elevator.useMotor = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && conditions.playerIsInside)
        {
            if (!elevatorIsActivated) ElevatorActivate();
            else ElevatorDeactivate();
        }
    }

}
