using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class Dog : MonoBehaviour, IDropHandler
{
    public Animator anim{get; protected set;}
    private string currentAnim;

    [SerializeField] private GameObject triggerTerror;
    public bool hasBeenFed;
    [SerializeField] private DogData dogData;
    private bool finishAnim = false;

    [SerializeField] private Item itemNeeded;

    
    // Start is called before the first frame update

    public void OnDrop(PointerEventData eventData){
        Debug.Log("Dropping...");
        if(eventData.pointerDrag!=null){
            var itemName = eventData.pointerDrag.transform.Find("ItemName").GetComponent<Text>();
            string text = itemName.text;
            Debug.Log(text);
            Debug.Log(itemNeeded.itemName);
            if(text == itemNeeded.itemName){
                InventoryManager.Instance.Remove(itemNeeded);
                hasBeenFed = true; //set sceneManager to true?
                triggerTerror.SetActive(false);
                ChangeToCalmIdleState();
            }else{
                Debug.Log("wrong item to give");
            }
        }
    }

    public void Start(){
        anim = GetComponent<Animator>();
        if(hasBeenFed){
            currentAnim = "idleCalm";
            ChangeToCalmIdleState();
            //calmState
        }else{
            currentAnim = "idleAngry";
            ChangeToAngryIdleState();
            //angryIdleState
        }
    }

    public void Update(){
        if(hasBeenFed){
            if(finishAnim){
                ChangeToCalmIdleState();
            }
        }else{
            if(finishAnim){
                ChangeToAngryIdleState();
            }
        }
    }

    public void ChangeToAngryState(){
        finishAnim = false;
        anim.SetBool(currentAnim, false);
        anim.SetBool("angry", true);
        currentAnim = "angry";
        //change to Bau bau bau and after a little change to idle back again
    }

    public void ChangeToCalmIdleState(){
        anim.SetBool(currentAnim, false);
        anim.SetBool("idleCalm", true);
        currentAnim = "idleCalm";
    }

    public void ChangeToAngryIdleState(){
        anim.SetBool(currentAnim, false);
        anim.SetBool("idleAngry", true);
        currentAnim = "idleAngry";
    }

    public void hasFinishAnim(){
        finishAnim=true;
    }


}
