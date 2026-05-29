using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour, IContactInteraction
{
    private PlayerStats stats;

    private void Start()
    {
        stats = GetComponentInParent<PlayerStats>();
    }

    public void OnContact()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyStats enemy = other.GetComponent<EnemyStats>();

        if (enemy != null)
        {
            stats.TakeDamage(enemy.atk);
            OnContact();
        }
    }
}
