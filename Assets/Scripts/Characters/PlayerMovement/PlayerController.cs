using UnityEngine;

public class PlayerController : MovementController
{
    public PlayerState CurrentState { get; private set; }

    public PlayerNormalState NormalState { get { return normalState; } }
    public PlayerShootState ShootState { get { return shootState; } }
    public PlayerDashState DashState { get { return dashState; } }

    [SerializeField] private PlayerNormalState normalState = new PlayerNormalState();
    [SerializeField] private PlayerShootState shootState = new PlayerShootState();
    [SerializeField] private PlayerDashState dashState = new PlayerDashState();

    protected override void Start()
    {
        base.Start();

        SetState(NormalState);
    }

    private void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.UpdateState(this);
            CurrentState.ChangeState(this);
        }
    }

    public void SetState(PlayerState newState)
    {
        if (CurrentState != null)
        {
            CurrentState.ExitState(this);
        }

        CurrentState = newState;

        if (CurrentState != null)
        {
            CurrentState.StartState(this);
        }
    }
}
