using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithE : MonoBehaviour
{
    bool hasCollided;
    public string labelText;
    public InteractInputHandler inputHandler{get; private set;}
    [SerializeField] private GameObject itemToActivate;

    private void Start(){
        hasCollided=false;
        inputHandler = GetComponent<InteractInputHandler>();
    }

    private void Update(){
        if(inputHandler.interactInput){
            //TODO call exit level function
            if(hasCollided){
                Debug.Log("call item to activate");
                itemToActivate.GetComponent<Interactable>().ActivateItem();
            }
        }
    }

    void OnGUI(){
        //Debug.Log("ONGUIIII");
        if(hasCollided==true){
            GUI.Box(new Rect(140,Screen.height-50,Screen.width-300,120),(labelText));
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag =="Player") 
        {
            hasCollided = true;
            //labelText = "Press E To Open The Gate!";
        }
    }
 
    void  OnTriggerExit2D(Collider2D other)
    {
        hasCollided = false;
    }
}
