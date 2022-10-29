using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    GameObject Target;
    Vector2 Movement = new Vector2();
    float movementSpeed = .6f;

    CombatAI AI = new CombatAI();
    bool InCombat = false;

    Rigidbody2D rigidBody;


    Range AttackRange;
    CapsuleCollider2D AggroRange;

    enum CharStates
    {
        IDLE = 0,
        COMBAT = 1,
        RUN = 2,
    }
    private void EnterCombat(GameObject target)
    {
        Target = target;
        Animator.SetInteger("AnimState", (int)CharStates.COMBAT);
        // Start Combat AI;
    }

    private void ExitCombat()
    {
        Animator.SetInteger("AnimState", (int)CharStates.IDLE);
    }

    /*Private CombatDecisions AI; { // AI Class that returns decisions to enemy, enemy executes decisions
        // Attack when player is close, Later add varience to this
        // Move towards player when far
        // Toss in sprinkle of Randomness
        // Potentially add different patterns that are cycled through randomly, such as Aggressive Stance for 6-12 secs, Passive Stance for 4 secs, Zoning stance for 2-4 secs
        // Each Stance has a list of options that are chosen based on player's distance, attack status and health
    }*/

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        AttackRange = GetComponentInChildren<Range>();

        Initialize();
        AI.Initialize(AttackRange);

        //Player = GameObject.Find("Player");
    }
    private void Update()
    {
        if (InAction || !isAlive)
            return;
        /*if (Input.GetKeyDown(KeyCode.Q))
        {
            ExitCombat();
            InAction = true;
        }*/
        Tactic Tactic = AI.DecideTactic();
        if (Tactic.Movement == Tactic.movement.FORWARD && Target != null)
        {
            Animator.SetInteger("AnimState", (int)CharStates.RUN);
            Movement = new Vector2(Target.transform.position.x - rigidBody.transform.position.x, 0);
            rigidBody.velocity = new Vector2(Movement.x * movementSpeed, rigidBody.velocity.y);
        }
        if (Tactic.Action == Tactic.action.ATTACK)
        {
            Attack();
        } 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EnterCombat(collision.gameObject);
        }
            
    }
}
