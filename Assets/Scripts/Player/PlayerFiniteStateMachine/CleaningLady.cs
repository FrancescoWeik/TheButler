using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class CleaningLady : Player, IDropHandler,IPointerDownHandler{

    public DialogueTrigger trigger;
    public Dialogue dialogue;
    [SerializeField] AudioClip audioClip;


    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            switch(text){
                default: 
                    dialogue.name = "CleaningLady";
                    dialogue.sentences = new string[1];
                    dialogue.sentences[0] = "I don't need anything else, I already know everything now!";//"As long as I have pizza I don't need anything else";
                    trigger.TriggerDialogue(dialogue);
                    break;
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            if(!audioSource.isPlaying){
                    audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
