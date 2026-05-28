using UnityEngine;

[System.Serializable]
public class PlayerDashState : PlayerState
{
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private float currentTime;

    Vector3 velocity;

    public override void StartState(PlayerController player)
    {
        currentTime = dashTime;

        Vector3 direction = player.transform.forward;

        if (InputHandler.instance.Move != Vector2.zero)
        {
            direction = Camera.main.transform.right * InputHandler.instance.Move.x + Camera.main.transform.forward * InputHandler.instance.Move.y;
            direction.y = 0f;
            direction = direction.normalized;
        }

        velocity = dashSpeed * direction;
    }

    public override void UpdateState(PlayerController player)
    {
        player.FaceDirection(velocity, 1500f);

        player.ApplyMovement(velocity);
    }

    public override void ChangeState(PlayerController player)
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            player.SetState(player.NormalState);
        }
    }

    public override void ExitState(PlayerController player)
    {
        
    }
}
