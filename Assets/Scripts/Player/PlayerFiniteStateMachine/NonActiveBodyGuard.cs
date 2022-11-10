using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class NonActiveBodyGuard :  MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject activeBodyGuard;
    [SerializeField] private GameObject activeUIBodyGuard;
    [SerializeField] private GameObject mechEye;

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            //Debug.Log(text);
            switch(text){
                case "EyeBall": GiveEyeState(); break;
                default: Debug.Log("what do I have to do with that one?"); break;
            }
        }

    }

    public void GiveEyeState(){
        Debug.Log("Entered Function");
        activeBodyGuard.SetActive(true);
        activeUIBodyGuard.SetActive(true);
        mechEye.SetActive(false);
        gameObject.SetActive(false);
    }
}
