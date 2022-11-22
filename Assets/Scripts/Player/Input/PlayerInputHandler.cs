using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 rawMovementInput{get; private set;}
    public int normalizedInputX{get; private set;}
    public int normalizedInputY{get; private set;}
    public bool jumpInput{get; private set;}
    public bool jumpInputStop{get; private set;}
    public bool attackInput{get; private set;}
    public bool swapInput{get; private set;}
    public bool shootInput{get; private set;}
    public bool interactInput{get; private set;}
    //public bool[] AttackInputs{get; private set;}

    [SerializeField] private float inputHoldTime = 0.1f;
    [SerializeField] private GameObject pauseMenu;

    private float jumpInputStartTime;

    private void Start(){
        //int count = Enum.GetValues(typeof(CombatInputs)).Length;
        //AttackInputs = new bool[count];
    }

    private void Update(){
        CheckJumpInputHoldTime();
    }

    /*public void OnPrimaryAttackInput(InputAction.CallbackContext context){
        if(context.started){
            AttackInputs[(int)CombatInputs.primary] = true;
        }
        if(context.canceled){
            AttackInputs[(int)CombatInputs.primary] = false;
        }
    }

    public void OnSecondaryAttackInput(InputAction.CallbackContext context){
        if(context.started){
            AttackInputs[(int)CombatInputs.secondary] = true;
        }
        if(context.canceled){
            AttackInputs[(int)CombatInputs.secondary] = false;
        }
    }*/

    public void OnMoveInput(InputAction.CallbackContext context){
        //Debug.Log("move input...");
        rawMovementInput = context.ReadValue<Vector2>();

        normalizedInputX = Mathf.RoundToInt(rawMovementInput.x);
        normalizedInputY = Mathf.RoundToInt(rawMovementInput.y);
        //normalizedInputX = (int)(rawMovementInput * Vector2.right).normalized.x;
        //normalizedInputY = (int)(rawMovementInput * Vector2.up).normalized.y;

    }

    public void OnJumpInput(InputAction.CallbackContext context){
        if(context.started){
            Debug.Log("STARTED");
            jumpInput = true;
            jumpInputStop = false;
            jumpInputStartTime = Time.time;
        }

        if(context.canceled){
            jumpInputStop = true;
        }
    }

    public void OnMenuInput(InputAction.CallbackContext context){
        //Debug.Log("WEEEEEEEEEE");
        if(context.started){
            PauseMenuHandler.Instance.ActivateMenu();
        }
    }

    public void UseJumpInput(){
        jumpInput = false;
    }

    private void CheckJumpInputHoldTime(){
        if(Time.time >= jumpInputStartTime + inputHoldTime){
            jumpInput = false;
        }
    }

    public void OnInteractInput(InputAction.CallbackContext context){
        if(context.started){
            interactInput = true;
        }
        if(context.canceled){
            interactInput = false;
        }
    }

    public void OnSwapInput(InputAction.CallbackContext context){
        if(context.started){
            swapInput = true;
        }
        if(context.canceled){
            swapInput = false;
        }
    }

    public void OnShootInput(InputAction.CallbackContext context){
        Debug.Log("shootInput...");
        if(context.started){
            shootInput = true;
        }
        if(context.canceled){
            shootInput = false;
        }
    }
}

/*public enum CombatInputs{
    primary,
    secondary
}*/