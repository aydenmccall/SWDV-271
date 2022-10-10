using UnityEngine;

public class Player : Character
{
    MovementController MovementController;
    void Start()
    {
        MovementController = gameObject.AddComponent<MovementController>();
    }

    private void Attack()
    {
         
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                print("Hit: " + hitObject.objectName);

                /*switch (hitObject.itemType)
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

                
            }
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StableGround") || collision.gameObject.CompareTag("Enemy"))
        {
            print("GROUND");
            MovementController.ResetJump();
        }
        //print(collision.gameObject.tag);
    }
}