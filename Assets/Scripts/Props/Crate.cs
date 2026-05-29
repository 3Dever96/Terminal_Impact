using UnityEngine;

public class Crate : CharacterStats
{ 
    [SerializeField] private GameObject loot;

    protected override void Die()
    {
        Instantiate(loot, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
