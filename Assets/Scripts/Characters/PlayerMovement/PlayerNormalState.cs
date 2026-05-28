using UnityEngine;

[System.Serializable]
public class PlayerNormalState : PlayerState
{
    [SerializeField] private float moveSpeed;

    private float currentSpeed;

    private Vector3 lookDirection;

    private bool canDash;

    public override void StartState(PlayerController player)
    {
        lookDirection = player.transform.forward;

        canDash = false;
    }

    public override void UpdateState(PlayerController player)
    {
        Vector3 direction = Camera.main.transform.right * InputHandler.instance.Move.x + Camera.main.transform.forward * InputHandler.instance.Move.y;
        direction.y = 0f;
        direction = direction.normalized;

        if (InputHandler.instance.Move != Vector2.zero)
        {
            currentSpeed = moveSpeed;
            lookDirection = direction;
        }
        else
        {
            currentSpeed = 0f;
        }

        player.FaceDirection(lookDirection);

        Vector3 velocity = lookDirection * currentSpeed;
        velocity.y = -5f;

        player.ApplyMovement(velocity);
    }

    public override void ChangeState(PlayerController player)
    {
        if (InputHandler.instance.Attack)
        {
            player.SetState(player.ShootState);
        }

        if (InputHandler.instance.Dash && canDash)
        {
            player.SetState(player.DashState);
        }

        if (!InputHandler.instance.Dash && !canDash)
        {
            canDash = true;
        }
    }

    public override void ExitState(PlayerController player)
    {
        
    }
}
