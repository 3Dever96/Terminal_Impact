using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform launcher;

    private int remainingClipLength;
    private float currentRoundTime;
    private float currentReloadTime;

    private void Start()
    {
        player = GetComponent<PlayerController>();

        if (weapon != null)
        {
            remainingClipLength = weapon.clipSize;
            currentReloadTime = weapon.reloadTime;
            currentRoundTime = weapon.fireRate;
        }
    }

    private void Update()
    {
        if (weapon != null)
        {
            if (player.CurrentState == player.ShootState)
            {
                // Shooting
                if (remainingClipLength > 0)
                {
                    currentRoundTime -= Time.deltaTime;

                    if (currentRoundTime <= 0f)
                    {
                        PlayerProjectile bullet = PlayerProjectilePool.instance.GetProjectile();

                        if (bullet != null)
                        {
                            bullet.Shoot(launcher.position, launcher.forward * weapon.bulletSpeed, weapon.bulletDamage);
                            currentRoundTime = weapon.fireRate;
                            remainingClipLength--;
                        }
                    }
                }
                else
                {
                    currentReloadTime -= Time.deltaTime;
                    if (currentReloadTime <= 0f)
                    {
                        remainingClipLength = weapon.clipSize;
                        currentReloadTime = weapon.reloadTime;
                        currentRoundTime = weapon.fireRate;
                    }
                }
            }
            else
            {
                if (remainingClipLength <= 0)
                {
                    currentReloadTime -= Time.deltaTime;
                    if (currentReloadTime <= 0f)
                    {
                        remainingClipLength = weapon.clipSize;
                        currentReloadTime = weapon.reloadTime;
                        currentRoundTime = weapon.fireRate;
                    }
                }
            }
        }
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        remainingClipLength = weapon.clipSize;
        currentReloadTime = weapon.reloadTime;
        currentRoundTime = weapon.fireRate;
    }
}
