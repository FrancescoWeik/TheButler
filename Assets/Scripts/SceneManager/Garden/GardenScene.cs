using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenScene : SceneLoader
{
    [SerializeField] private GardenData data;
    [SerializeField] private Dog dog;
    [SerializeField] private GameObject triggerCheck;

    protected override void Start(){
        base.Start();
        Instance = this;
        if(data.alreadyFed == true){
            triggerCheck.SetActive(false);
            dog.hasBeenFed = true;
        }
    }

    public override void SaveSceneState(){
        if(dog.hasBeenFed == true){
            data.alreadyFed = true;
        }
    }
    
}