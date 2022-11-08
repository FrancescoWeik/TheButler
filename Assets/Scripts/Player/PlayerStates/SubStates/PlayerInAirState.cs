using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int xInput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool coyoteTime; //per evitare che prema spazio alla fine di un precipizio e cade senza saltare(se sbaglia a premere e fa tardi salta lo stesso.)
    private bool isJumping;
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        //CheckCoyoteTime();

        xInput = player.inputHandler.normalizedInputX;
        jumpInput = player.inputHandler.jumpInput;
        jumpInputStop = player.inputHandler.jumpInputStop;
        CheckJumpMultiplier();

        if(isGrounded && player.currentVelocity.y < 0.01f){
            stateMachine.ChangeState(player.landState);
        }
        else if(jumpInput && player.jumpState.CanJump()){
            stateMachine.ChangeState(player.jumpState);
        }
        //TODO VOLA CON OMBRELLO, AL POSTO DELL'ELSE IF PROBABILMENTE
        //////////////
        else{
            player.CheckIfShouldFlip(xInput);
            player.SetVelocityX(playerData.movementVelocity * xInput);

            player.anim.SetFloat("yVelocity", player.currentVelocity.y);
            player.anim.SetFloat("xVelocity", Mathf.Abs(player.currentVelocity.x));
        }
    }

    private void CheckJumpMultiplier(){
        if(isJumping){
            if(jumpInputStop){
                player.SetVelocityY(player.currentVelocity.y * playerData.variableJumpHeightMultiplier);
                isJumping = false;
            }
            else if(player.currentVelocity.y<=0f){
                //Debug.Log(stateMachine.currentState);
                isJumping = false;
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    /*private void CheckCoyoteTime(){
        if(coyoteTime && Time.time > startTime + playerData.coyoteTime){
            coyoteTime = false;
            player.jumpState.DecreaseAmountOfJumpsLeft();
        }
    }*/

    public void StartCoyoteTime(){
        coyoteTime = true;
    }

    public void SetIsJumping(){
        isJumping = true;
    }
}
