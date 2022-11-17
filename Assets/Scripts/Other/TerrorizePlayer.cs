using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrorizePlayer : MonoBehaviour
{
    [SerializeField] private string layerToHit;
    private int playerLayer;
    [SerializeField] private Dog dog;

    public void Start(){
        playerLayer = LayerMask.NameToLayer(layerToHit);
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer == playerLayer){
            Debug.Log("EnteredCollider");
            //col.gameObject.GetComponent<Player>().DamageHop(-200.0f,20.0f);
            col.gameObject.GetComponent<Player>().ChangeToTerrorState();
            dog.ChangeToAngryState();
            //change to hop state
        }
    }
}
