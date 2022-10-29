using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health
{
    private float health;
    protected GameObject character;
    Animator animator;
    public Slider slider;
    public Health(GameObject Character, Animator Animator, Slider Slider = null, int HealthAmount = 100)
    {
        slider = Slider;
        health = HealthAmount;
        character = Character;
        animator = Animator;
    }

    public void UpdateHealth()
    {
        slider.value = GetHealth();
    }
    public float GetHealth()
    {
        return health;
    }
    public void Damage(float value)
    {
        health -= value;
        UpdateHealth();
        if (health <= 0)
            Die();
        // Check if Dead
    }
    public bool IsDead()
    {
        if (GetHealth() <= 0)
        {
            Die();
            return true;
        }
        return false;
    }
    private void Die()
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Hurt");
        animator.SetTrigger("Death");
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(4);
        GameObject.Destroy(character);
    }
    public void Heal(float value)
    {
        if (health < 100 && health > 0)
        {
            health += value;
            UpdateHealth();
        }
    }
}

