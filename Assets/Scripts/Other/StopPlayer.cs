using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopPlayer : MonoBehaviour
{
    [SerializeField] private string layerToHit;
    private int playerLayer;
    [SerializeField] private DialogueTrigger trigger;

    public void Start(){
        playerLayer = LayerMask.NameToLayer(layerToHit);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == playerLayer){
            //check if it is cleanLady, if it isn't then terrorize him
            if(col.gameObject.GetComponent<Player>().id!=2){
                Debug.Log("EnteredCollider");
                col.gameObject.GetComponent<Player>().ChangeToTerrorState();
                trigger.TriggerDialogue();
            }
        }
    }
}