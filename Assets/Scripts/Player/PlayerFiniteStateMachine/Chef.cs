using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chef : Player{
    [SerializeField] private GameObject checkTrigger;
    protected override void Update(){
        if(Controlling && checkTrigger.active){
            //disable checkPlayerTrigger
            checkTrigger.SetActive(false);
        }else if(!Controlling && !checkTrigger.active){
            //enableCheck
            checkTrigger.SetActive(true);
        }
        base.Update();
    }

    public void MessageTriggerAnim(){
        anim.SetBool("idle", false);
        anim.SetBool("triggered", true);
        return;
    }
}
