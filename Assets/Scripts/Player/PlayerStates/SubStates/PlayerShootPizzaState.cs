using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootPizzaState : PlayerAbilityState
{
    private float velocityToSet;
    private bool setVelocity;
    protected GameObject projectile;
    protected Transform attackPosition;
    //protected Projectile projectileScript;

    public PlayerShootPizzaState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName, Transform attackPosition) : base(player, stateMachine, playerData, animBoolName)
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
        Debug.Log("Entered Shooting Pizza");
        if(player.CheckIfGrounded()){
            SetPlayerVelocity(playerData.movementAttackSpeed);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetPlayerVelocity(float velocity){
        player.SetVelocityX(velocity*player.facingDirection);
        velocityToSet = velocity;
        setVelocity = true;
    }

    public void ShootPizza(){
        //Debug.Log(attackPosition);
        //Debug.Log(projectile);
        projectile = GameObject.Instantiate(playerData.projectile, attackPosition.position, attackPosition.rotation);
        //Debug.Log(attackPosition.transform.right);
        projectile.GetComponent<Rigidbody2D>().velocity = attackPosition.transform.right * playerData.projectileSpeed;
        //projectileScript = projectile.GetComponent<Projectile>();
        //projectileScript.velocity = attackPosition.transform.right * playerData.projectileSpeed;
        //projectileScript.FireProjectile(stateData.projectileSpeed, stateData.projectileTravelDistance, stateData.projectileDamage, stateData.lifeTime);
    }

    #region Animation Triggers
    public override void AnimationFinishTrigger(){
        //base.AnimationFinishTrigger();
        //Debug.Log("FINISH ATTACK STATE IN PLAYERRRRRRRRRRRRRRR");
        //isAbilityDone = true;
        Debug.Log("changing state.... from shooting to idle");
        stateMachine.ChangeState(player.idleState);
    }
    #endregion
}
