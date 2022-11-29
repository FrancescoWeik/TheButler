using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class NonActiveCharacter :  MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject activeCharacter;
    [SerializeField] private GameObject activeUICharacter;
    [SerializeField] private GameObject mechEye;
    [SerializeField] private Dialogue dialogueIfCorrect;
    [SerializeField] private Dialogue dialogueIfWrong;
    [SerializeField] private Item itemNeeded;
    [SerializeField] private bool isBodyGuard;


    public DialogueTrigger trigger;

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            Debug.Log(text);
            Debug.Log(itemNeeded.itemName);
            if(text == itemNeeded.itemName){
                trigger.TriggerDialogue(dialogueIfCorrect);
                InventoryManager.Instance.Remove(itemNeeded);
                GiveItemState();
            }else{
                trigger.TriggerDialogue(dialogueIfWrong);
                Debug.Log("wrong item to give");
            }
        }

            /*switch(text){
                case "EyeBall": GiveEyeState(); break;
                default: 
                    dialogue.name = "Bodyguard";
                    dialogue.sentences = new string[1];
                    dialogue.sentences[0] = "What do I have to do with that one?";
                    trigger.TriggerDialogue(dialogue);
                    Debug.Log("what do I have to do with that one?"); break;
            }*/
    }

    public virtual void GiveItemState(){
        Debug.Log("Entered Function");
        if(isBodyGuard){
            mechEye.SetActive(false);
            InventoryManager.Instance.pickedMechEye = true;
            activeCharacter.SetActive(true);
            //activeUICharacter.SetActive(true);
            gameObject.SetActive(false);
        }else{
            activeCharacter.SetActive(true);
            //activeUICharacter.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
