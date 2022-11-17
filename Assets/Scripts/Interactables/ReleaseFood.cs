using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseFood : MonoBehaviour
{
    [SerializeField] private GameObject food;
    public bool alreadyObtained; // initialized by the kitchenscene element
    [SerializeField] private Transform positionToInstantiate;
    public void MessageActivateItem(){
        if(!alreadyObtained){
            GameObject steak = Instantiate(food, positionToInstantiate.position, Quaternion.identity) as GameObject;
            alreadyObtained = true;
        }
    }
}
