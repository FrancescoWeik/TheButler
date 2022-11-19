using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class WindowRope : MonoBehaviour, IDropHandler
{
    public bool ropeOnWindow;
    private SpriteRenderer spriteRenderer;
    [SerializeField] Sprite windowRopeSprite;
    [SerializeField] private Item itemNeeded;
    private Animator anim;
    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            Debug.Log(text);
            Debug.Log(itemNeeded.itemName);
            if(text == itemNeeded.itemName){
                InventoryManager.Instance.Remove(itemNeeded);
                ropeOnWindow = true; //set sceneManager to true?
                changeToOpenWindow();

            }else{
                Debug.Log("wrong item to give");
            }
        }
    }

    public void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void changeToRopeSprite(){
        spriteRenderer.sprite = windowRopeSprite;
        anim.SetBool("open",true);
    }

    public void changeToOpenWindow(){
        anim.SetBool("open",true);
    }
}
