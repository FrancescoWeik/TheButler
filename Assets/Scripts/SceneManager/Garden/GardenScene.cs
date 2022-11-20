using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenScene : SceneLoader
{
    [SerializeField] private SceneData data;
    [SerializeField] private Dog dog;
    [SerializeField] private GameObject triggerCheck;
    [SerializeField] private GameObject window;
    [SerializeField] private Sprite openWindow;

    protected override void Start(){
        base.Start();
        Instance = this;
        Debug.Log(data.alreadyFed);
        if(data.alreadyFed == true){
            //Debug.Log("HAS BEEN FED");
            triggerCheck.SetActive(false);
            dog.hasBeenFed = true;
        }
        if(data.ropeOnWindow == true){
            window.GetComponent<SpriteRenderer>().sprite = openWindow;
            window.GetComponent<ChangeSceneDoor>().enabled = true;
        }else{
            window.GetComponent<ChangeSceneDoor>().enabled = false;
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(dog.hasBeenFed == true){
            data.alreadyFed = true;
        }
    }
    
}