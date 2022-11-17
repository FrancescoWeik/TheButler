using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class WindowHouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public GameObject canvas;

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("enter called");
    }

    public void OnPointerExit(PointerEventData eventData){
        Debug.Log("Exit called");
    }

    public void OnPointerDown(PointerEventData eventData){
        if(eventData.button == PointerEventData.InputButton.Left){
            Debug.Log(eventData);
            OpenUI();
            
        }
    }

    public void OpenUI(){
        if(canvas.activeSelf){
            canvas.SetActive(false);
        }else{
            canvas.SetActive(true);
        }
    }
}
