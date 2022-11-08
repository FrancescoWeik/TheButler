using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objectToCall;
    [SerializeField] int playerLayer;

    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == playerLayer){
            objectToCall.SendMessage("MessageTriggerAnim");
            //send message
        }else{
            //Do Nothing
        }
        //Debug.Log("WEEE");
    }
}
