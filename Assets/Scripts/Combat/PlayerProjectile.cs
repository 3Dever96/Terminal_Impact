using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerProjectile : MonoBehaviour, IContactInteraction
{
    private Rigidbody body;
    private int damage;

    private void OnEnable()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody>();
        }
    }

    public void Shoot(Vector3 origin, Vector3 velocity, int newDamage)
    {
        transform.position = origin;
        transform.rotation = Quaternion.LookRotation(velocity);

        body.linearVelocity = velocity;

        damage = newDamage;
    }

    public void OnContact()
    {
        PlayerProjectilePool.instance.QueueProjectile(this);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnContact();
    }
}
