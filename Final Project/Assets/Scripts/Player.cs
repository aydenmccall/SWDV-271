using UnityEngine;

public class Player : Character
{
    MovementController MovementController;
    Hitbox Hitbox;
    private void Start()
    {
        MovementController = gameObject.AddComponent<MovementController>();
        Hitbox = gameObject.GetComponentInChildren<Hitbox>();
    }

    private void Update()
    {
        ReadInput();
    }

    void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Attack(90);
        }
    }

    private void Attack(int attackFrames)
    {
        Hitbox.setActive(attackFrames);
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
            MovementController.ResetJump();
        }
        //print(collision.gameObject.tag);
    }
}