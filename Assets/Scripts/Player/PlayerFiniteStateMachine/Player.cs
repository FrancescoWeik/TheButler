using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Check if player is being controlled.
    public bool Controlling = false;
    #region SingleTon Instantiation for Player Used For camera AND CAMERA EFFECT AND GAMEMANAGER
    // Singleton instantiation
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<Player>();
            return instance;
        }
    }

    public CameraEffects cameraEffects;
    public GameManager gameManager;
    #endregion
    #region Health and Others
    public int currentHealth{get; private set;}
    public int maxHealth{get; private set;}

    #endregion
    #region State variables

    public PlayerStateMachine stateMachine{get; private set;}
    public PlayerIdleState idleState{get; private set;}
    public PlayerMoveState moveState{get; private set;}
    public PlayerJumpState jumpState{get; private set;}

    public PlayerPrepareShootingState prepareShootingState{get; private set;}
    public PlayerShootPizzaState shootState{get; private set;}
    public bool canShoot = false;
     
    public PlayerInAirState inAirState{get; private set;}
    public PlayerLandState landState{get; private set;}
    public PlayerTerrorState terrorState{get; private set;}

    [SerializeField] protected PlayerData playerData;
    public int id;
    public string name;

    #endregion
    #region Components

    public Animator anim{get; protected set;}
    public AudioSource audioSource{get; private set;}
    public PlayerInputHandler inputHandler{get; private set;}
    public Rigidbody2D rb {get; protected set;}
    public PlayerInventory inventory {get; private set;}
    [SerializeField] private ParticleSystem jumpParticles;
    public SpriteRenderer spriteRenderer{get; private set;}
    [SerializeField] private GameObject overlappingCircle;

    #endregion
    #region CheckTransforms Variables
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform characterSwapCheck;
    [SerializeField] protected Transform attackRangePosition;

    #endregion
    #region Timer Variables

    public float trackAttackTime;
    public float lastHurtTime;
    private float spriteBlinkingTotalTimer = 0.0f;
    private float spriteBlinkingTimer = 0.0f;

    #endregion
    #region Other Variables

    private Shader shaderGUIWhite;
    private Shader shaderSpritesDefault;    
    public Vector2 currentVelocity{get; private set;}
    public int facingDirection{get; protected set;}
    private bool startBlinking = false;
    private bool normalSprite = true; //needed to check whether to blink or not

    private Vector2 workspace;

    [SerializeField] protected GameObject terrorObject;
    #endregion
    #region UI Objects
    [SerializeField] private GameObject deathMenu;
    #endregion
    #region Unity Callback Functions
    protected virtual void Awake(){
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, playerData, "idle");
        moveState = new PlayerMoveState(this, stateMachine, playerData, "move");
        jumpState = new PlayerJumpState(this, stateMachine, playerData, "inAir"); //blendTree for jump
        inAirState = new PlayerInAirState(this, stateMachine, playerData, "inAir"); //blendTree for jump
        landState = new PlayerLandState(this, stateMachine, playerData, "land");
        terrorState = new PlayerTerrorState(this, stateMachine, playerData, "move");

        shootState = new PlayerShootPizzaState(this, stateMachine, playerData, "shoot", attackRangePosition);
        prepareShootingState = new PlayerPrepareShootingState(this,stateMachine,playerData,"prepareShoot", attackRangePosition);
    }

    protected virtual void Start(){
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        inputHandler = GetComponent<PlayerInputHandler>();
        rb = GetComponent<Rigidbody2D>();
        inventory = GetComponent<PlayerInventory>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //Debug.Log("AOISHGSIUAAPI");
        //Debug.Log(rb);

        shaderGUIWhite = Shader.Find("GUI/Text Shader");
        shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used

        id = playerData.id;

        trackAttackTime = Time.time;
        lastHurtTime = 0f;
        maxHealth = playerData.maxHealth;
        currentHealth = playerData.maxHealth;

        facingDirection = 1; //always start facing the right;
        
        terrorObject.SetActive(false);
        stateMachine.Initialize(idleState);
    }

    protected virtual void Update(){
        currentVelocity = rb.velocity;

        if(startBlinking){
            StartBlinking();
        }

        stateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate(){
        stateMachine.currentState.PhysicsUpdate();
    }
    #endregion
    #region Set Functions
    public void SetVelocityX(float velocity){
        workspace.Set(velocity, currentVelocity.y);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void SetVelocityY(float velocity){
        workspace.Set(currentVelocity.x, velocity);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    public void SetGravityRB(float gravityScale){
        rb.gravityScale = gravityScale;
    }
   
    public void SetWhiteSprite(){
        spriteRenderer.material.shader = shaderGUIWhite;
        spriteRenderer.color = Color.white;
        normalSprite = false;
    }

    public void SetNormalSprite(){
        spriteRenderer.material.shader = shaderSpritesDefault;
        spriteRenderer.color = Color.white;
        normalSprite = true;
    }

    public void SetTerrorActive(){
        terrorObject.SetActive(true);
    }

    public void SetTerrorNonActive(){
        terrorObject.SetActive(false);
    }

    public void setControllingData(bool control){
        playerData.ControllingData = control;
    }

    #endregion
    #region Check Functions
    public void CheckIfShouldFlip(int xInput){
        if(xInput!=0 && xInput != facingDirection){
            Flip();
        }
    }

    public void CheckIfShouldFlipAiming(Vector2 mousePos){
        if(mousePos.x < transform.position.x && facingDirection==-1){ //sinistra
            Debug.Log("non devo flippare");
        }else if(mousePos.x > transform.position.x && facingDirection == 1){
            Debug.Log("non devo flippare");
        }else{
            Flip();
        }
    }

    public bool CheckIfGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.whatIsGround);
    }

    public bool CheckSwap(){
        Collider2D[] players = Physics2D.OverlapCircleAll(characterSwapCheck.position, playerData.characterSwapCheckRadius, playerData.whatIsPlayer);
        //Debug.Log(players.Length);
        if(players.Length >= 2){
            return true;
        }else{
            return false;
        }
    }

    #endregion
    #region Other Functions

    private void AnimationTrigger(){
        stateMachine.currentState.AnimationTrigger();
    }

    private void AnimationFinishTrigger(){
        stateMachine.currentState.AnimationFinishTrigger();
    }

    private void finishTriggerAnim(){
        anim.SetBool("triggered", false);
        anim.SetBool("idle", true);
    }

    private void Flip(){
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void ShowCircle(){
        overlappingCircle.SetActive(true);
    }

    public void HideCircle(){
        overlappingCircle.SetActive(false);
    }

    public void SwapCharacter(){
        //OpenSwapMenu(); //this is a ui with buttons that the user can click with the mouse or keyboard in order to change character.
        Debug.Log("Here I should be able to change the player that I'm controlling");
        Collider2D[] players = Physics2D.OverlapCircleAll(characterSwapCheck.position, playerData.characterSwapCheckRadius, playerData.whatIsPlayer);
        GameManager.Instance.OpenCharactersMenu(players);
        //Debug.Log(players);
    }

    public virtual void ReceiveItem(Item item){

    }

    public virtual void ChangeToTerrorState(){
        stateMachine.ChangeState(terrorState);
    }

    //private 

    #endregion
    #region Damage and Animation Callback Functions
    public virtual void DamageHop(float velocityX, float velocityY){
        Debug.Log("HOP");
        workspace.Set(velocityX,velocityY);
        rb.velocity = workspace;
        currentVelocity = workspace;
    }

    private void StartBlinking(){
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= playerData.waitAfterHurtTime){
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            SetNormalSprite();
            return;
        } 
        spriteBlinkingTimer += Time.deltaTime;
        if(spriteBlinkingTimer >= playerData.spriteBlinkingMiniDuration){
            spriteBlinkingTimer = 0.0f;
            if (normalSprite){
                SetWhiteSprite();  //make changes
            }else{
                SetNormalSprite();   //make changes
            }
        }
    }

    private void HurtEffect()
    {
        //GameManager.Instance.audioSource.PlayOneShot(hurtSound);
        audioSource.PlayOneShot(playerData.hurtSound);
        //StartCoroutine(FreezeFrameEffect()); -----> tolto perchè da problemi se muoio, come sistemare...?
        //GameManager.Instance.audioSource.PlayOneShot(hurtSounds[whichHurtSound]);
        audioSource.PlayOneShot(playerData.hurtSounds[playerData.whichHurtSound]);

        if (playerData.whichHurtSound >= playerData.hurtSounds.Length - 1)
        {
            playerData.whichHurtSound = 0;
        }
        else
        {
            playerData.whichHurtSound++;
        }
        cameraEffects.Shake(100, 1f);
    }

    public IEnumerator FreezeFrameEffect(float length = .007f)
    {
        Time.timeScale = .1f;
        yield return new WaitForSeconds(length);
        Time.timeScale = 1f;
    }

    public void Die()
    {
        Debug.Log("WAAAAAAAAAAA");
        deathMenu.SetActive(true);
        gameObject.SetActive(false);
        //lostTextObject.SetActive(true);
        //lostButton.SetActive(true);
        //Debug.Log("Dead");
    }

    public void PlayStepSound()
    {
        //Play a step sound at a random pitch between two floats, while also increasing the volume based on the Horizontal axis
        audioSource.pitch = (Random.Range(1f, 1.3f));
        audioSource.PlayOneShot(playerData.stepSound, Mathf.Abs(0.7f));
    }

    public void PlayJumpSound()
    {
        audioSource.pitch = (Random.Range(1f, 1f));
        audioSource.PlayOneShot(playerData.jumpSound, .1f);
    }
    
    public void LandEffect()
    {
        jumpParticles.Emit(1);
        audioSource.pitch = (Random.Range(0.6f, 1f));
        audioSource.PlayOneShot(playerData.landSound);
    }

    public void JumpEffect()
    {
        if(CheckIfGrounded()){
            jumpParticles.Emit(1);
            audioSource.pitch = (Random.Range(1f, 1.5f));
            audioSource.volume = 0.7f;
            audioSource.PlayOneShot(playerData.landSound);
        }

    }

    public void PunchEffect()
    {
        audioSource.PlayOneShot(playerData.punchSound);
        //cameraEffects.Shake(100, 1f);
    }

     public void PoundEffect()
    {
    }

    #endregion
    #region GizmosFunctions
    public void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundCheck.position, playerData.groundCheckRadius);
        Gizmos.DrawWireSphere(characterSwapCheck.position, playerData.characterSwapCheckRadius);
    }

    #endregion

}
