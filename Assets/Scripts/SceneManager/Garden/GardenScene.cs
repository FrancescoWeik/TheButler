using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenScene : SceneLoader
{
    [SerializeField] private SceneData data;
    [SerializeField] private Dog dog;
    [SerializeField] private GameObject triggerCheck;

    protected override void Start(){
        base.Start();
        Instance = this;
        Debug.Log(data.alreadyFed);
        if(data.alreadyFed == true){
            triggerCheck.SetActive(false);
            dog.hasBeenFed = true;
        }else{
            Debug.Log("ERORRRRRRRRRRRRRRRRRRRRRRRR");
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(dog.hasBeenFed == true){
            data.alreadyFed = true;
        }
    }
    
}