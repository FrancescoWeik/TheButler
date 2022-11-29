using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    public int id; //which character it is
    public RuntimeAnimatorController currentController;
    public bool ControllingData=false;

    [Header("PlayerStats")]
    public int maxHealth = 6;
    public float waitAfterHurtTime = 0.35f;
    public float gravityScale = 5f;

    //[Header("SomeReferences")]
    //[SerializeField] public GameObject pauseMenu;
    //[SerializeField] public ParticleSystem jumpParticles;

    [Header("AllPlayerSounds")]
    public AudioClip deathSound;
    public AudioClip equipSound;
    public AudioClip grassSound;
    public AudioClip hurtSound;
    public AudioClip[] hurtSounds;
    public AudioClip holsterSound;
    public AudioClip jumpSound;
    public AudioClip landSound;
    public AudioClip poundSound;
    public AudioClip punchSound;
    public AudioClip[] poundActivationSounds;
    public AudioClip outOfAmmoSound;
    public AudioClip stepSound;
    public AudioClip eyeSound;
    [System.NonSerialized] public int whichHurtSound;

    [Header("MoveState")]
    public float movementVelocity = 10f;

    [Header("JumpState")]
    public float jumpVelocity = 15f;
    public int amountOfJumps = 1;

    [Header("InAirState")]
    public float coyoteTime = 0.1f;  
    public float variableJumpHeightMultiplier = 0.5f; 

    [Header("GlideState")]
    public float glideVelocity = 5f;

    [Header("CheckVariables")]
    public float groundCheckRadius = 0.3f;
    public float characterSwapCheckRadius = 1f;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;

    [Header("AttackState")]
    public float waitBetweenAttacksTime = 0.35f;
    public float movementAttackSpeed = 0f;
    public float projectileSpeed = 15f;
    public GameObject projectile;
    public GameObject point;
    public int numberOfPoints = 15;
    public float spaceBetweenPoints = 0.025f;

    [Header("HurtState")]
    public Vector2 hurtLaunchPower; //How much force should be applied to the player when getting hurt?
    public float launchRecovery = 3f; //How slow should recovering from the launch be? (Higher the number, the longer the launch will last)
    public float spriteBlinkingMiniDuration = 0.1f; //time between each blink
    //public float spriteBlinkingTotalDuration = 1.0f; //total duration of blinking when hurt

    [Header("TerrorState")]
    public float terrorVelocity = 20.0f;
    public float terrorTime = 3.0f;

    public void ResetAll(){
        ControllingData = false;
    }

    public void ResetAll(RuntimeAnimatorController ac){
        currentController = ac;
    }
}
