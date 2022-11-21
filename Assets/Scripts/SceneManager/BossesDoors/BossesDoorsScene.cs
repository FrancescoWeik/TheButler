using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossesDoorsScene : SceneLoader
{
    [SerializeField] public SceneData data;
    [SerializeField] private WindowRope windowRope;
    [SerializeField] private GameObject passwordFields;
    [SerializeField] private GameObject passwordWall;
    [SerializeField] private Item mechEye;

    protected override void Start(){
        base.Start();
        Instance = this;
        if(data.ropeOnWindow){
            windowRope.changeToRopeSprite();
        }
        if(GameManager.Instance.currentPlayerId == 0){
            //maggiordomo
            //Devo vedere però che abbia anche indossato l'occhio meccanico...
            if(InventoryManager.Instance.mechEye == true){
                //mostra la password della porta + porta cojn password + posto dove cliccare per inserire password
                passwordFields.SetActive(true);
                passwordWall.SetActive(true);
            }
        }else{
            Debug.Log("Not Butler");
        }
    }

    protected void Update(){
        if(GameManager.Instance.currentPlayerId!=0){
            passwordFields.SetActive(false);
            passwordWall.SetActive(false);
        }else{
            if(InventoryManager.Instance.mechEye){
                passwordFields.SetActive(true);
                passwordWall.SetActive(true);
            }
        }
    }

    public override void SaveSceneState(){
        base.SaveSceneState();
        if(windowRope.ropeOnWindow){
            data.ropeOnWindow = true;
        }
    }
    
}