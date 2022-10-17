using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private float movementSpeed = 4.0f;
    private float jumpForce = 20;
    private bool isJumping = false;
    Vector2 movement = new Vector2();

    // 1
    Animator animator;

    // 2
    string animationState = "AnimationState";
    Rigidbody2D rb2D;

    // 3
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,

        idleSouth = 5
    }

    public enum Directions
    {
        Right = 1,
        Left = 2
    }

    public Directions FacingDir = Directions.Right;

    public void Initiliaze(float speed = 4)
    {
        // 4
        movementSpeed = speed; 
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Updates() 
    {
        // 5
        UpdateState();
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !isJumping)
        {
            isJumping = true;
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void FixedUpdates()
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
        rb2D.velocity = new Vector2(movement.x * movementSpeed, rb2D.velocity.y);
        //rb2D.velocity = movement * movementSpeed;
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
            //gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {
            FacingDir = Directions.Left;
            //gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            //animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        /*else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }*/
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }
}