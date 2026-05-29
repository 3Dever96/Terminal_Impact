using UnityEngine;

public class PlayerStats : CharacterStats, IDamageable
{
    private PlayerController player;

    protected override void Start()
    {
        base.Start();

        player = GetComponent<PlayerController>();
    }

    public new void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHp -= damage;

            // player.SetState(player.HitState);

            if (currentHp <= 0f)
            {
                Die();
            }

            StartCoroutine(Invincible());
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}
