using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    BoxCollider2D RangeCollider;
    public bool isInRange;
    //BoxCollider2D CloseRangeBox;
    //BoxCollider2D AirRangeBox;
    /*public void Initialize(BoxCollider2D collider)
    {
        RangeCollider = collider;
    }*/

    private void Start()
    {
        RangeCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is BoxCollider2D && collision.gameObject.CompareTag("Player"))
            isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision is BoxCollider2D && collision.gameObject.CompareTag("Player"))
            isInRange = false;
    }
}
