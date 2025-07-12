using UnityEngine;

public class Player : MonoBehaviour
{
    #region Variables
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdelState playerIdelState { get; private set; }
    public PlayerMoveState playerMoveState { get; private set; }
    public PlayerSprintState playerSprintState { get; private set; }
    public PlayerJumpState playerJumpState { get; private set; }
    public PlayerInAirState playerInAirState { get; private set; }
    public PlayerLandState playerLandState { get; private set; }
    public PlayerInputHandler playerInputHandler { get; private set; }
    public Vector2 CurruntVelocity { get; private set; }
    public Vector2 Workspace;
    private Vector3 _scale;
    public Animator Anim { get; private set; }
    public Rigidbody2D RB { get; private set; }
    [SerializeField] Data playerData;
    [SerializeField] private Transform _groundCheck;
    #endregion
    #region Unity Callback Functions
    void Awake()
    {

        Anim = GetComponent<Animator>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine = new PlayerStateMachine();
        playerIdelState = new PlayerIdelState(this, StateMachine, playerData, "idle");
        playerMoveState = new PlayerMoveState(this, StateMachine, playerData, "walk");
        playerJumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        playerInAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        playerLandState = new PlayerLandState(this, StateMachine, playerData, "land");
        playerSprintState = new PlayerSprintState(this, StateMachine, playerData, "sprint");
    }
    void Start()
    {
        StateMachine.Initialize(playerIdelState);
        _scale = transform.localScale;
    }
    void Update()
    {
        CurruntVelocity = RB.linearVelocity;
        StateMachine.playerState.LogicUpdate();
    }
    void FixedUpdate()
    {
        StateMachine.playerState.PhysicsUpdate();
    }
    #endregion
    #region Set Functions
    public void SetWalkingVelocity(float velocity)
    {
        Workspace.Set(velocity, CurruntVelocity.y);
        RB.linearVelocity = Workspace;
        CurruntVelocity = Workspace;
    }
    public void SetJumpVelocity(float velocity)
    {
        Workspace.Set(CurruntVelocity.x, velocity);
        RB.linearVelocity = Workspace;
        CurruntVelocity = Workspace;
    }
    public void SetSprintingVelocity(float velocity)
    {
        Workspace.Set(velocity, CurruntVelocity.y);
        RB.linearVelocity = Workspace;
        CurruntVelocity = Workspace;
    }

    #endregion
    #region Check Functions

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, playerData.GroundCheckRadius, playerData.WhatIsGround);
    }

    #endregion
    #region Other Functions

    private void AnimationTrigger() => StateMachine.playerState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.playerState.AnimationFinishTrigger();
    public void Flip()
    {
        if (playerInputHandler.MovementInput.x < 0 && _scale.x > 0)
        {
            _scale.x = -1;
            transform.localScale = _scale;
        }
        else if (playerInputHandler.MovementInput.x > 0 && _scale.x < 0)
        {
            _scale.x = 1;
            transform.localScale = _scale;
        }
    }
    #endregion
}
