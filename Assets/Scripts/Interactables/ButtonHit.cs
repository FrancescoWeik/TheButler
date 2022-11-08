using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public GameObject objectToActivate;
    public void MessageButtonHit(){
        Debug.Log("Entrato nel message!");
        objectToActivate.SendMessage("MessageActivateItem");
    }
}
