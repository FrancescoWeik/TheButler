using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public GameObject ovenButton;
    public GameObject objectToActivate;
    private SpriteRenderer sprite;
    public void MessageButtonHit(){
        Debug.Log("Entrato nel message!");
        objectToActivate.SendMessage("MessageActivateItem");
        if(ovenButton!=null){
            sprite = ovenButton.GetComponent<SpriteRenderer>();
            sprite.color = Color.green;
        }
    }
 
}
