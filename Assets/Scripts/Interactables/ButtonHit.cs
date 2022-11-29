using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public GameObject ovenButton;
    public GameObject objectToActivate;
    private SpriteRenderer sprite;
    private bool alreadyHit = false;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public void MessageButtonHit(){
        Debug.Log("Entrato nel message!");
        objectToActivate.SendMessage("MessageActivateItem");
        if(!alreadyHit){
            audioSource.PlayOneShot(audioClip);
        }
        if(ovenButton!=null){
            sprite = ovenButton.GetComponent<SpriteRenderer>();
            sprite.color = Color.green;
        }
    }

    public void SetAlreadyHit(){
        alreadyHit = true;
    }
 
}
