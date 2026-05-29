using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectilePool : MonoBehaviour
{
    public static PlayerProjectilePool instance;

    public Queue<PlayerProjectile> projectile = new Queue<PlayerProjectile>();

    private void Awake()
    {
        instance = this;

        PlayerProjectile[] projectiles = GetComponentsInChildren<PlayerProjectile>();

        for (var i = 0; i < projectiles.Length; i++)
        {
            QueueProjectile(projectiles[i]);
            projectiles[i].gameObject.SetActive(false);
        }
    }

    public PlayerProjectile GetProjectile()
    {
        if (projectile.Count > 0)
        {
            PlayerProjectile newProjectile = projectile.Dequeue();

            newProjectile.gameObject.SetActive(true);

            return newProjectile;
        }

        return null;
    }

    public void QueueProjectile(PlayerProjectile newProjectile)
    {
        projectile.Enqueue(newProjectile);
    }
}
