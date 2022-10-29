using System.Collections;
using UnityEngine;

public class Player : Character
{
    // Initialize Gameobjects
  // public GameObject InventoryPrefab;

    // Initialize Scripts
    public UIManager UIManager;
    public Game_Manager GameManager;

    private void Start()
    {
        //UIManager = new UIManager(InventoryPrefab);
        //UIManager.Initialize();
        Initialize();
    } //End Start

    private void Update()
    {
        ReadInput();
    } // End Update

    override protected void Die()
    {
       // print("Die Start");
        isAlive = false;
        Animator.SetTrigger("Death");
        StartCoroutine(Respawn());
    }


    IEnumerator Respawn()
    {
        int counter = 4;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        //GameManager.SpawnPlayer();
        GameManager.Restart();
        Destroy(gameObject);
    }

    public void Revive()
    {
        Animator.SetTrigger("Revive");
    }

    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dodge();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Damage(100);
        }
    } // End ReadInput

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Item Item = collision.gameObject.GetComponent<Consumable>().Item;

            //print(Item);

            if (Item != null)
            {
                //print(Item.objectName);

                //UIManager.Inventory.AddItem(consumable);
                switch(Item.itemType)
                {
                    case Item.ItemType.COIN:
                        if (UIManager.Inventory.AddItem(Item))
                            collision.gameObject.SetActive(false);
                        break;
                    case Item.ItemType.KEY:
                        if (UIManager.Inventory.AddItem(Item))
                            collision.gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
                /*switch (Item.itemType)
                {
                    case Item.ItemType.COIN:
                        print("MONEY!!");
                        collision.gameObject.SetActive(false);
                        break;
                    case Item.ItemType.HEALTH:
                        //AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }*/
                //collision.gameObject.SetActive(false);

            }
            
        }
    } // End OnTriggerEnter2D

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!collision.gameObject.GetComponent<Enemy>().isAlive)
                Physics.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), collider);
        }
    }*/

}