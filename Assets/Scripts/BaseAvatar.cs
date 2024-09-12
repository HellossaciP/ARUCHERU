using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAvatar : MonoBehaviour
{

    [SerializeField] float maxSpeed;
    [SerializeField] protected float maxHealth;
    protected float health;

    bool invincible;

    // Start is called before the first frame update
    void Start()
    {
        invincible = false;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getMaxSpeed()
    {
        return maxSpeed;
    }

    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    protected abstract void Die();

    public float GetHealthRatio()
    {
        return health/maxHealth;
    }

    public void SetInvincibility(bool invincibility)
    {
        invincible = invincibility;
    }
}
