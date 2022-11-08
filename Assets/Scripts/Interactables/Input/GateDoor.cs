using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateDoor : MonoBehaviour
{
    bool hasCollided;
    public string labelText;
    public InteractInputHandler inputHandler{get; private set;}
    [SerializeField] private GameObject door;
    // Start is called before the first frame update
    private void Start(){
        hasCollided=false;
        inputHandler = GetComponent<InteractInputHandler>();
    }

    private void Update(){
        if(inputHandler.interactInput){
                //TODO call exit level function
                if(hasCollided){
                    Debug.Log("call Open Door");
                    OpenDoor();
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

    private void OpenDoor(){
        //call open door
        door.GetComponent<openingDoor>().OpenDoor();
    }

    public void MessageActivateItem(){
        door.GetComponent<openingDoor>().OpenDoor();
    }
}
