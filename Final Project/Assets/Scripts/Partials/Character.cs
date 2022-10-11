using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public Health Health;
    protected Animator Animator;
    private string animationState = "AnimationState";

    void Start()
    {
        Health = new Health(gameObject);
        Animator = gameObject.GetComponent<Animator>();
    }

     private enum animations{
            damage = 0
        }

    public void Damage(int DamageAmount)
    {
        if (Animator == null)
            return;

        Health.Damage(DamageAmount);
        print("Damage: " + DamageAmount);
        Animator.SetTrigger("Damage");
        print("Remaining Health: " + Health.getHealth());
    }
}
