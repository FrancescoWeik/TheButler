using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingDoor : MonoBehaviour
{
    [SerializeField] private float lift;
    [SerializeField] private float speed;
    //Forse aggiungo camera e la faccio "shakarare" un poco
    private bool move;
    private bool alreadyMoved;
    private Vector3 temp;

    private void Start(){
        alreadyMoved = false;
        move = false;
    }

    private void Update(){
        if(move){
            //Debug.Log("opening...");
            alreadyMoved = true;
            transform.position = Vector3.MoveTowards(transform.position, temp, speed);
        }
    }

    public void OpenDoor(){
        if(!alreadyMoved){
            Debug.Log("SHOULD OPEN....");
            temp = transform.position;
            temp.y += lift;
            //wall.transform.position = temp;
            //wall.transform.position = Vector3.MoveTowards(wall.transform.position, temp, speed)
            move = true;
        }
    }
}
