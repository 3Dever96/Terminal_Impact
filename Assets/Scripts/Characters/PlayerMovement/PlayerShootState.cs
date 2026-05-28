using UnityEngine;

[System.Serializable]
public class PlayerShootState : PlayerState
{
    [SerializeField] private float moveSpeed;

    private float currentSpeed;

    private bool canDash;

    public override void StartState(PlayerController player)
    {
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
        }
        else
        {
            currentSpeed = 0f;
        }

        Vector3 look = Camera.main.transform.forward;
        look.y = 0f;
        look = look.normalized;

        player.FaceDirection(look, 1500f);

        Vector3 velocity = direction * currentSpeed;
        velocity.y = -5f;

        player.ApplyMovement(velocity);
    }

    public override void ChangeState(PlayerController player)
    {
        if (!InputHandler.instance.Attack)
        {
            player.SetState(player.NormalState);
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
