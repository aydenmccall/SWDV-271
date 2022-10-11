using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float health;
    protected GameObject character;
    public Health(GameObject Character, int HealthAmount = 100)
    {
        health = HealthAmount;
        character = Character;
    }
    public float getHealth()
    {
        return health;
    }
    public void Damage(float value)
    {
        health -= value;
        if (health <= 0)
            Die();
        // Check if Dead
    }
    private void Die()
    {
        GameObject.Destroy(character);
    }
    public void Heal(float value)
    {
        if (health < 100 && health > 0)
        {
            health += value;
        }
    }
}

