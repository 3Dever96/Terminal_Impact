using System.Collections;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour, IDamageable
{
    [Header("Stats")]
    [SerializeField] protected int maxHp;
    [SerializeField] protected int currentHp;
    public int atk;

    [Header("Invincibility")]
    [SerializeField] private float iFrames;

    [SerializeField] private float blinkTime;

    protected bool isInvincible;

    [SerializeField] private GameObject avatar;

    protected virtual void Start()
    {
        currentHp = maxHp;
    }

    private void Update()
    {
        if (currentHp <= 0f)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHp -= damage;

            StartCoroutine(Invincible());
        }
    }

    protected virtual void Die()
    {
        print(name + " has died.");
    }

    protected IEnumerator Invincible()
    {
        float currentI = iFrames;

        isInvincible = true;

        while (currentI > 0f)
        {
            currentI -= Time.deltaTime;

            avatar.SetActive(!avatar.activeInHierarchy);

            yield return new WaitForSeconds(blinkTime);
        }

        avatar.SetActive(true);
        isInvincible = false;
    }
}
