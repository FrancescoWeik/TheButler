using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInputHandler : MonoBehaviour
{
    public bool interactInput{get; private set;}
    public void OnInteractInput(InputAction.CallbackContext context){
        if(context.started){
            interactInput=true;
        }
        if(context.canceled){
            interactInput = false;
        }
    }
}
