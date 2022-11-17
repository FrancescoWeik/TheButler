using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class clickItemToTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public DialogueTrigger trigger;

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("enter called");
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("Exit called");
    }

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            Debug.Log(eventData);
            trigger.TriggerDialogue();
        }
    }
}
