using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerformAnimationState : PlayerGroundedState
{
    private bool giveItem;
    private Item item;

    public PlayerPerformAnimationState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, bool giveItem, Item item):base(player, stateMachine, playerData, animBoolName){
        this.giveItem = giveItem;
        this.item = item;
    }
    
    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
    }

    public override void Exit()
    {
        if(giveItem){
            player.ReceiveItem(item);
        }
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished){
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
