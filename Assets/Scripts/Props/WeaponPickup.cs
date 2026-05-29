using UnityEngine;

public class WeaponPickup : MonoBehaviour, IContactInteraction
{
    [SerializeField] private Weapon weapon;

    public void OnContact()
    {
        PlayerWeaponController playerWeapon = FindAnyObjectByType<PlayerWeaponController>();

        playerWeapon.EquipWeapon(weapon);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnContact();
        }
    }
}
