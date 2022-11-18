using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScene : SceneLoader
{
    [SerializeField] private GateDoor door;
    [SerializeField] private GameObject knife;
    [SerializeField] private ButtonHit hitButton;
    [SerializeField] private SceneData data;
    [SerializeField] private GameObject Chef;
    [SerializeField] private GameObject fullChef;
    [SerializeField] private ReleaseFood foodReleaser;
    [SerializeField] private ButtonHit foodButton;
    public bool food;
    protected override void Start(){
        base.Start();
        food = data.foodObtained;
        Instance = this;
        if(data.ovenOpened){
            hitButton.MessageButtonHit();
            door.OpenDoor();
        }
        if(data.gotKnife){
            Destroy(knife);
        }
        if(data.chefActive){
            Destroy(fullChef);
        }
        if(data.foodObtained){
            foodReleaser.alreadyObtained = true;
            foodButton.MessageButtonHit();
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(door.opened){
            Debug.Log("OVEN OPENED");
            data.ovenOpened = true;
        }
        if(knife==null){
            data.gotKnife = true;
        }
        if(Chef !=null){
            if(Chef.activeSelf == true){
                data.chefActive = true;
            }
        }
        if(InventoryManager.Instance.pickedSteakUp){
            data.foodObtained = true;
        }
    }
    
}
