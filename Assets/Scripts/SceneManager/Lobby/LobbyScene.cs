using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : SceneLoader
{

    [SerializeField] private GameObject CleaningLady;
    [SerializeField] private GameObject fullCleaningLady;
    [SerializeField] private SceneData data;

    protected override void Start(){
        base.Start();
        Instance = this;

        if(data.cleaningLadyActive){
            Destroy(fullCleaningLady);
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(CleaningLady !=null){
            if(CleaningLady.activeSelf == true){
                data.cleaningLadyActive = true;
            }
        }
    }
    
}
