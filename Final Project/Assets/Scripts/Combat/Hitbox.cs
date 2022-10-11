using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    BoxCollider2D Collider;
    private bool isActive = false;
    private int activeFrames;
    private void Start()
    {
         Collider = gameObject.GetComponent<BoxCollider2D>();
        Collider.enabled = false;
    }

    private void Update()
    {
        if (isActive == true)
        {
            CountFrames();
        }
    }

    public void setActive(int ActiveFrames = 10)
    {
        isActive = true;
        activeFrames = ActiveFrames;
        Collider.enabled = true;
    }

    private void CountFrames()
    {
        if (activeFrames > 0)
        {
            activeFrames -= 1;
            return;
        }
        isActive = false;
        Collider.enabled = false;
        return;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (!isActive)
            return;*/

        if (collision.gameObject.CompareTag("Enemy"))
        {
            print("Parry this you filthy casual! : Enemy");
            collision.gameObject.GetComponent<Enemy>().Damage(10);
            return;
        }
    }
}
