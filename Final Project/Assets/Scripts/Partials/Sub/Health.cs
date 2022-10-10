using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float health;
    public float getHealth()
    {
        return health;
    }
    public void damage(float value)
    {
        health -= value;
        // Check if Dead
    }
    public void heal(float value)
    {
        if (health < 100 && health > 0)
        {
            health += value;
        }
    }
}

