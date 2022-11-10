using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class BodyGuard : Player, IDropHandler{

    public PlayerPerformAnimationState performAnimation{get; private set;}
    private bool alreadyCutEye;
    [SerializeField] Item futuristicEye;
    [SerializeField] Item eyeBall;
    
    protected override void Awake(){
        base.Awake();
        performAnimation = new PlayerPerformAnimationState((Player)this, stateMachine, playerData, "performAnim", true, futuristicEye); //ricevi Item
    }

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            Debug.Log(itemName.text);
        }

    }

    protected override void Start(){
        base.Start();
        facingDirection = -1;
        stateMachine.ChangeState(performAnimation);
    }

    public override void ReceiveItem(Item item){
        Debug.Log(item);
        if(item.itemName == "MechEye"){
            InventoryManager.Instance.Remove(eyeBall);
        }
        InventoryManager.Instance.Add(item);
    }
}