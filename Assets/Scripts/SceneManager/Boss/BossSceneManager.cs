using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneManager : SceneLoader
{
    [SerializeField] private SceneData data;

    protected override void Start(){
        base.Start();
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
    }
    
}