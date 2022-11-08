using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPrepareShootingState : PlayerAbilityState
{
    public GameObject point;
    GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;
    protected Transform attackPosition;
    Vector2 direction;
    //private int xInput;
    public PlayerPrepareShootingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Transform attackPosition) : base(player, stateMachine, playerData, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        numberOfPoints = playerData.numberOfPoints;
        spaceBetweenPoints = playerData.spaceBetweenPoints;
        player.SetVelocityX(0f);
        points = new GameObject[numberOfPoints];
        for(int i=0; i<numberOfPoints; i++){
            points[i] = GameObject.Instantiate(playerData.point,attackPosition.position, Quaternion.identity);
        }
    }
    public override void Exit()
    {
        for(int i=0; i<numberOfPoints; i++){
            UnityEngine.Object.Destroy(points[i]);
        }
        base.Exit();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(0f);
        //xInput = player.inputHandler.normalizedInputX;
        //player.CheckIfShouldFlip(xInput);
        Vector2 pizzaPosition = attackPosition.position;
        Vector3 mos_pos = Mouse.current.position.ReadValue();
        mos_pos.z = Camera.main.nearClipPlane;
        Vector3 mos_world_pos = Camera.main.ScreenToWorldPoint(mos_pos);
        Vector2 mousePosition = new Vector2(mos_world_pos.x,mos_world_pos.y);
        player.CheckIfShouldFlipAiming(mousePosition);//Flip(mousePosition);

        direction = mousePosition - pizzaPosition;
        for(int i=0; i<numberOfPoints; i++){
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
        if(!player.inputHandler.shootInput){
            stateMachine.ChangeState(player.shootState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    Vector2 PointPosition(float t){
        Vector2 position = (Vector2)attackPosition.position + (direction.normalized * playerData.projectileSpeed * t) + 0.5f * Physics2D.gravity * (t*t); 
        return position;
    }
}
