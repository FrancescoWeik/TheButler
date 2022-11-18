using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScene : SceneLoader
{
    [SerializeField] private SceneData data;
    [SerializeField] private WindowUI windowUI;
    [SerializeField] private GameObject rope;

    protected override void Start(){
        base.Start();
        Instance = this;
        if(data.ropeObtained){
            rope.SetActive(false);
        }
        if(data.gaveFoto){
            windowUI.alreadyGiven = true;
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(windowUI.alreadyGiven){
            data.gaveFoto = true;
        }

        if(InventoryManager.Instance.pickedRope){
            data.ropeObtained = true;
        }
    }
    
}
