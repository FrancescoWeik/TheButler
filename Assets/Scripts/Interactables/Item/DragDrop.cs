using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerUpHandler
{   
    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector3 startPosition; 
    //private Collider2D collider;
    //private bool canUse;

    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("InventoryCanvas").GetComponent<Canvas>(); //other ways to do it with a prefab?....
        canvasGroup = GetComponent<CanvasGroup>();
        //collider = GetComponent<BoxCollider2D>();
        //canUse = false;
    }

    public void OnPointerDown(PointerEventData eventData){
        GameManager.Instance.DisableCharacter();

        Debug.Log("mouseDown");
    }

    public void OnPointerUp(PointerEventData eventData){
        Debug.Log("mouseUp");
        GameManager.Instance.EnableSameCharacter();
    }

    public void OnPointerEnter(PointerEventData eventData){
        //Debug.Log("enter called");
        //Show item description(?)
    }

    public void OnPointerExit(PointerEventData eventData){
        //Debug.Log("Exit called");
        //Remove item description(?)
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnBeginDrag(PointerEventData eventData){
        startPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("OnBeginDrag");
    }

    public void OnEndDrag(PointerEventData eventData){
        //check collider, check player type and activate item
        Debug.Log("EndDrag Activate Item");
        canvasGroup.blocksRaycasts = true;
        GameManager.Instance.EnableSameCharacter();
        /*if(canUse){

        }*/
        //if I don't activate the item then
        rectTransform.anchoredPosition= startPosition;
        //canUse = false;
    }

    /*public void  OnTriggerStay2D(Collider2D col){
        Debug.Log(col);
        //If player Do something, else nothing (for now)
        if(col.GetComponent<Player>()!=null){
            canUse = true;
        }else{
            canUse= false;
        }
    }*/
    
}
