using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class Butler : Player, IDropHandler
{
    public PlayerPerformAnimationState performAnimation{get; private set;}
    private bool alreadyCutEye;
    [SerializeField] Item eyeBall;


    protected override void Awake(){
        base.Awake();
        performAnimation = new PlayerPerformAnimationState((Player)this, stateMachine, playerData, "performAnim", true, eyeBall);
    }

    public void ChangeToCutEyeState(){
        stateMachine.ChangeState(performAnimation);
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var item = eventData.pointerDrag;
            var itemName =item.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            Debug.Log(text);
            switch(text){
                case "Knife": 
                    if(!alreadyCutEye){
                        ChangeToCutEyeState();
                        alreadyCutEye = true;
                    }else{
                        //Mostra dialogo con ("No please, not again.");
                        Debug.Log("Not Again");
                    }
                    break;
                default: Debug.Log("what do I have to do with that one?"); break;
            }
        }

    }

    public override void ReceiveItem(Item item){
        Debug.Log("RECEIVuing...");
        Debug.Log(item);
        InventoryManager.Instance.Add(item);
    }
}
