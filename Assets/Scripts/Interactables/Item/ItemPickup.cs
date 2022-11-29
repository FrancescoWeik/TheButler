using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Item item;

    void Pickup(){
        InventoryManager.Instance.Add(item);
        InventoryManager.Instance.PlayPickSound();
        Destroy(gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("enter called");
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("Exit called");
    }

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            Pickup();
        }
    }
}
