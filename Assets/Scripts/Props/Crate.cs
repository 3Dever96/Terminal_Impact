using UnityEngine;

public class Crate : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp;
    [SerializeField] private GameObject loot;

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Instantiate(loot, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
