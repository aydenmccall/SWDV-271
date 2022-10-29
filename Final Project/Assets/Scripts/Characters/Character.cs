using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public abstract class Character : MonoBehaviour
{
    public Health Health;
    protected Animator Animator;
    protected Hitbox Hitbox;
    public Slider Slider;
    //protected Transform Hitbox;
    public LayerMask enemyLayers;
    public bool PreAction = false;
    public bool InAction = false;
    public bool IsInvulnerable = false;
    public bool IsBlocking = false;
    public int Poise = 0;
    public bool isAlive = true;

    public CharType charType;
    //private string animationState = "AnimationState";

    public enum CharType
    {
        ALLY = 1,
        ENEMY = 2
    }



    virtual protected void Die()
    {
        isAlive = false;
        Animator.SetTrigger("Death");
    }

    public void Initialize()
    {
        Animator = gameObject.GetComponent<Animator>();
        Hitbox = gameObject.GetComponentInChildren<Hitbox>();
        Hitbox.Initiliaze(charType);
        Health = new Health(gameObject, Animator, Slider);
    }

    protected void Dodge()
    {
        if (InAction)
            return;
        Animator.SetTrigger("Dodge");
    }

    protected void Attack() //AttackInfo AttackInfo)
    {
        if (InAction || PreAction)
            return;
        Animator.SetTrigger("Attack"); // based on active frames
    } // End Attack

    public void Damage(int DamageAmount, int poiseDamage = 1)
    {

        if (Poise > poiseDamage)
        {
            Poise -= poiseDamage;
            Health.Damage(Mathf.RoundToInt(DamageAmount/2));
            if (Health.IsDead())
            {
                Die();
                return;
            }
            Animator.SetTrigger("Armor");
            return;
        }
            

        Health.Damage(DamageAmount);
        if (Health.IsDead())
        {
            Die();
            return;
        }
        Animator.SetTrigger("Hurt");
    }
}
