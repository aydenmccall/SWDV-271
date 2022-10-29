using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float movementSpeed = 5.0f;
    private float jumpForce = 20;
    private bool isJumping = false;

    Vector2 movement = new Vector2();

    public bool isGrounded = false;
    private float heightSlack = .01f;


    public Text debugText;

    BoxCollider2D boxCollider;
    Animator animator;
    Rigidbody2D rb2D;
    Character Character;
    enum CharStates
    {
        idle = 0,
        combatIdle = 1,
        run = 2
    }

    public enum Directions
    {
        Right = 1,
        Left = 2
    }

    public Directions FacingDir = Directions.Right;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Character = GetComponent<Character>();
    }

    public void Update()
    {
        // 5
        checkGrounded();
        if (Character.InAction)
            return;

        if (!Character.PreAction)
            UpdateState();
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !isJumping) // Jump Mechanic
        {
            Jump();
        }
    }

    public void FixedUpdate()
    {
        // 6
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        // 7
        movement.Normalize();
        if (Character.InAction)
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        else if (Character.PreAction)
            rb2D.velocity = new Vector2(movement.x * (movementSpeed/2), rb2D.velocity.y);
        else
            rb2D.velocity = new Vector2(movement.x * movementSpeed, rb2D.velocity.y);
       // lastMotion = movement;
        //rb2D.velocity = movement * movementSpeed;
    }

    private void Jump()
    {
            if (Character.InAction)
                return;
            isJumping = true;
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("Grounded", false);
        animator.SetTrigger("Jump");

    }

    void checkGrounded()
    {

        RaycastHit2D hit = Physics2D.Raycast(boxCollider.bounds.center, Vector2.down, boxCollider.bounds.extents.y + heightSlack);
        if (hit.collider != null)
            debugText.text = "Grounded";
        else
            debugText.text = "Airborne";
    }

    public void ResetJump()
    {
        isJumping = false;
    }

    private void UpdateState()
    {
        // 8
        if (movement.x > 0)
        {
            FacingDir = Directions.Right;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetInteger("AnimState", (int)CharStates.run);
        }
        else if (movement.x < 0)
        {
            FacingDir = Directions.Left;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            animator.SetInteger("AnimState", (int)CharStates.run);
        }
        else
        {
            animator.SetInteger("AnimState", (int)CharStates.idle);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("StableGround"))
        {
            animator.SetBool("Grounded", true);
            ResetJump();
        }
    } // End OnCollisionEnter2D
}