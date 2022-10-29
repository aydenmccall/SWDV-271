using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAI
{
    public IEnumerator coroutine;
    Tactic Tactic = new Tactic();
    Range Range;
    //private GameObject Player;


    public void Initialize(Range range)
    {
        Range = range;
    }

    public Tactic DecideTactic() // Return Tactic
    {
        if (Range.isInRange)
        {
            Tactic.Action = Tactic.action.ATTACK;
            Tactic.Movement = Tactic.movement.IDLE;
            return Tactic; // Attack, if too close back away
        }
            
        Tactic.Action = Tactic.action.IDLE;
        Tactic.Movement = Tactic.movement.FORWARD;
        return Tactic; // Advance
    }
}
