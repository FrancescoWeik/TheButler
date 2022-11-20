using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowToGarden : ChangeSceneDoor
{
    public DialogueTrigger trigger;
    public override void OnPointerDown(PointerEventData eventData){
        if(GameManager.Instance.currentPlayerId == 2){
            //Cleaning Lady
             trigger.TriggerDialogue();
        }else{
            base.OnPointerDown(eventData);
        }
    }
}
