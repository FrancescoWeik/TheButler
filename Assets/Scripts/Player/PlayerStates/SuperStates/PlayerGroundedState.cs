using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    //protected Vector2 input;
    protected int xInput;
    private bool jumpInput;
    private bool isGrounded;
    private bool swapInput;
    private bool shootInput;
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
    }

    public override void Enter()
    {
        base.Enter();

        player.jumpState.ResetAmountOfJumpsLeft();
        //Debug.Log("groundedState");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //input = player.inputHandler.rawMovementInput;
        xInput = player.inputHandler.normalizedInputX;
        jumpInput = player.inputHandler.jumpInput;
        swapInput = player.inputHandler.swapInput;
        shootInput = player.inputHandler.shootInput;
        if(swapInput && isGrounded){
            //stateMachine.ChangeState(player.idleState);
            player.SwapCharacter();   
            player.SetVelocityX(0f);
        }else if(shootInput){
            //shoot
            stateMachine.ChangeState(player.prepareShootingState);
        }
        if(jumpInput && player.jumpState.CanJump()){
            player.inputHandler.UseJumpInput(); //set jump bool variable to false.
            stateMachine.ChangeState(player.jumpState);
        }else if(!isGrounded){
            //player.jumpState.DecreaseAmountOfJumpsLeft();
            player.inAirState.StartCoyoteTime();
            stateMachine.ChangeState(player.inAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
