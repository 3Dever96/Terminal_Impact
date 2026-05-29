using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    protected override void Die()
    {
        base.Die();

        Destroy(gameObject);
    }

    public void OnContact()
    {

    }
}
