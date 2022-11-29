using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class BossScript : MonoBehaviour, IDropHandler
{
    [SerializeField] private Item itemNeeded;
    public DialogueTrigger trigger;
    public Dialogue dialogue;
    private Animator anim;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioClip angryAudio;

    public void Start(){
        anim = GetComponent<Animator>();
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var item = eventData.pointerDrag;
            var itemName =item.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            Debug.Log(text);
            if(text == itemNeeded.itemName){
                audioSource.PlayOneShot(audioClip);
                //EndGame
                Debug.Log("congratulations");
                InventoryManager.Instance.Remove(itemNeeded);
                ChangeToDeath();
            }else{
                if(!audioSource.isPlaying){
                    audioSource.PlayOneShot(angryAudio);
                }
                audioSource.PlayOneShot(angryAudio);
                dialogue.name = "Boss";
                dialogue.sentences = new string[1];
                dialogue.sentences[0] = "LEAVE ME ALONE!";
                trigger.TriggerDialogue(dialogue);
                Debug.Log("what do I have to do with that one?");
            }
        }

    }

    public void ChangeToDeath(){
        anim.SetBool("dead",true);
    }

    public void FinishGame(){
        Debug.Log("FinishedGame");
        endScreen.SetActive(true);
    }
}
