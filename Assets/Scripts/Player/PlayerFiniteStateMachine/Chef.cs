using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class Chef : Player, IDropHandler,IPointerDownHandler{
    [SerializeField] private GameObject checkTrigger;

    public DialogueTrigger trigger;
    public Dialogue dialogue;
    [SerializeField] AudioClip audioClip;

    protected override void Update(){
        if(playerData.ControllingData && checkTrigger.active){
            //disable checkPlayerTrigger
            checkTrigger.SetActive(false);
        }else if(!playerData.ControllingData && !checkTrigger.active){
            //enableCheck
            checkTrigger.SetActive(true);
        }
        base.Update();
    }

    public void MessageTriggerAnim(){
        anim.SetBool("idle", false);
        anim.SetBool("triggered", true);
        return;
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            switch(text){
                default: 
                    dialogue.name = "Chef";
                    dialogue.sentences = new string[1];
                    dialogue.sentences[0] = "Mamma Mia";//"As long as I have pizza I don't need anything else";
                    trigger.TriggerDialogue(dialogue);
                    Debug.Log("As long as I have pizza I don't need anything else"); break;
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            audioSource.PlayOneShot(audioClip);
        }
    }
}
