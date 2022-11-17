using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomScene : SceneLoader
{
    protected override void Start(){
        base.Start();
        Instance = this;
    }

    public override void SaveSceneState(){
    }
    
}