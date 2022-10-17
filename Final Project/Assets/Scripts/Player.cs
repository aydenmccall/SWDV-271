using UnityEngine;

public class Player : Character
{
    // Initialize Gameobjects
    public GameObject InventoryPrefab;

    // Initialize Scripts
    MovementController MovementController;
    Hitbox Hitbox;
    UIManager UIManager;

    private void Start()
    {
        UIManager = new UIManager(InventoryPrefab);
        UIManager.InitiliazeUI();
        MovementController = gameObject.AddComponent<MovementController>();
        Hitbox = gameObject.GetComponentInChildren<Hitbox>();
    } //End Start

    private void Update()
    {
        ReadInput();
    } // End Update

    void ReadInput()
    {
        {
        if (Input.GetKeyDown(KeyCode.H))
            Attack(90);
        }
    } // End ReadInput

    private void Attack(int attackFrames)
    {
        Hitbox.setActive(attackFrames);
    } // End Attack

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            Item Item = collision.gameObject.GetComponent<Consumable>().Item;

            //print(Item);

            if (Item != null)
            {
                print(Item.objectName);

                //UIManager.Inventory.AddItem(consumable);
                switch(Item.objectName)
                {
                    case "Coin":
                        print("Nice.");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StableGround") || collision.gameObject.CompareTag("Enemy"))
        {
            MovementController.ResetJump();
        }
    } // End OnCollisionEnter2D
}