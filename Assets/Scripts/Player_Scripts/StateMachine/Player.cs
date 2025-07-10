using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdelState playerIdelState { get; private set; }
    public PlayerMoveState playerMoveState { get; private set; }
    public PlayerInputHandler playerInputHandler { get; private set; }
    public Animator Anim { get; private set; }
    [SerializeField] Data playerData;

    void Awake()
    {

        Anim = GetComponent<Animator>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
        StateMachine = new PlayerStateMachine();
        playerIdelState = new PlayerIdelState(this, StateMachine, playerData, "idle");
        playerMoveState = new PlayerMoveState(this, StateMachine, playerData, "walke");
    }
    void Start()
    {
        StateMachine.Initialize(playerIdelState);
    }
    void Update()
    {
        StateMachine.playerState.LogicUpdate();
    }
    void FixedUpdate()
    {
        StateMachine.playerState.PhysicsUpdate();
    }
}
