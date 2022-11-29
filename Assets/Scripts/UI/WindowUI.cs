using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class WindowUI : MonoBehaviour, IDropHandler
{
    [SerializeField] private Item foto;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    public bool alreadyGiven;
    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            switch(text){
                case("Camera"):
                    //make flash
                    if(!alreadyGiven){
                        audioSource.PlayOneShot(audioClip);
                        InventoryManager.Instance.Add(foto);
                        alreadyGiven = true;
                        Debug.Log("FOTOOOOOOOO"); break;
                    }else{
                        break;
                    }
                default: 
                    Debug.Log("Wrong Item");
                    break;
            }
        }

    }

}
