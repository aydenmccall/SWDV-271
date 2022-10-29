using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tactic
{
    public movement Movement;
    public action Action;
    //public stance Stance;

    public enum movement 
    { 
        IDLE = 0,
        FORWARD = 1,
        BACKWARD = 2
    }
    public enum action 
    {
        IDLE = 0,
        ATTACK = 1,
        //ATTACKSTRING = 2,
        //BLOCK = 3
    }
   /* public enum stance // if defensive stance, react to jumps
    {
        IDLE = 0,
        DEFENSIVE = 1,
        AGGRESSIVE = 2
    }*/
}
