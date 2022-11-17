using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTerrorState : PlayerGroundedState
{
    protected bool isIdleTimeOver;
    protected float idleTime;

    public PlayerTerrorState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isIdleTimeOver = false;
        //player.SetVelocityX(playerData.terrorVelocity * -1);
        idleTime = playerData.terrorTime;
        player.SetTerrorActive();
    }

    public override void Exit()
    {
        player.SetTerrorNonActive();
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.CheckIfShouldFlip(-1);
        player.SetVelocityX(playerData.movementVelocity * -1);
        if(Time.time >= startTime + idleTime){
            isIdleTimeOver = true;
        }
        if( isIdleTimeOver){
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
