using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player; 
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isAnimationFinished;
    protected float startTime;

    private string animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName){
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter(){
        DoChecks();
        player.anim.SetBool(animBoolName, true);
        startTime = Time.time;
        //Debug.Log(animBoolName);
        isAnimationFinished = false;
    }

    public virtual void Exit(){
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate(){ //every frame

    }

    public virtual void PhysicsUpdate(){ //every fixedUpdate
        DoChecks();
    }

    public virtual void DoChecks(){
        //check if players inside the swap character circle...
        if(player.CheckSwap() && playerData.ControllingData){
            //Debug.Log("Show circle");
            player.ShowCircle();
        }else{
            //Debug.Log("Hide circle");
            player.HideCircle();
        }
    }

    public virtual void AnimationTrigger(){

    }

    public virtual void AnimationFinishTrigger(){
        isAnimationFinished = true;
    }
}
