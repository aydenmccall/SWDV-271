using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator Animator;
    public GameObject EndScreen;
    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    IEnumerator EndGame(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        EndScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            if (collision.gameObject.GetComponent<Player>().UIManager.Inventory.getItemSlot("Key") != -1)
            {
                Animator.SetTrigger("Open");
                StartCoroutine("EndGame", 3);
            }
        }
    }
}
