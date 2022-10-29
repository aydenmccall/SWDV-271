using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D Collider;
    private bool isActive = false;
    private int activeFrames;
    Character.CharType CharType;

    public void Initiliaze(Character.CharType charType)
    {
        /*Collider = gameObject.GetComponent<BoxCollider2D>();
        Collider.enabled = false;*/
        CharType = charType;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        /*if (!isActive)
            return;*/
       // print(collider.gameObject.CompareTag("Enemy"));
        //print(CharType);

        if (collider.gameObject.CompareTag("Enemy") && CharType == Character.CharType.ALLY && collider is BoxCollider2D)
        {
            Enemy Enemy = collider.gameObject.GetComponent<Enemy>();
            if (Enemy.IsBlocking)
            {

            }
            Enemy.Damage(10);
            return;
        }
        else if (collider.gameObject.CompareTag("Player") && CharType == Character.CharType.ENEMY && collider is BoxCollider2D)
        {
            Player Player = collider.gameObject.GetComponent<Player>();
            if (Player.IsInvulnerable)
            {
                //print("Dodged!");
                return;
            } else if (Player.IsBlocking)
            {
               // print("Blocked!");
                return;
            }
            Player.Damage(10);
            return;
        }
    }
}
