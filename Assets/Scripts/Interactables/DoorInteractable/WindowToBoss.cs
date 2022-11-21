using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowToBoss : ChangeSceneDoor, IPointerDownHandler
{
    public DialogueTrigger trigger;
    public override void OnPointerDown(PointerEventData eventData){
        if(GameManager.Instance.currentPlayerId == 2){
            //you are the cleaningLady
            //trigger dialogue
            trigger.TriggerDialogue();
        }else{
            base.OnPointerDown(eventData);
        }
    }
}
