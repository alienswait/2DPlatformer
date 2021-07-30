using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters : MonoBehaviour

    
{
    public enum MovementStates
    {
        idle,
        running,
        jumping,
        attacking
    }

    public enum FacingDirection
    {
        Right,
        left
    }

    public float movementspeed;
    public float jumpForce;
    float IsGroundedRayLength = 0.25f;


    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    
    public LayerMask platformLayerMask;
    public MovementStates characterMovementState;
    public FacingDirection facingDirection;

    // Update is called once per frame
    void Update()
    {
        HandleJump(); 
    }

    private void FixedUpdate()
    {
        HandleMovement();
        IsGrounded();
        PlayAnimationsBasedOnState();
    }
    /// <summary>
    /// This method handles jumping
    /// </summary>

    private void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            animator.SetBool("isjumping", true);
            rigidbody2D.velocity = Vector2.up * jumpForce;
        }
    }

    private void HandleMovement()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.velocity = new Vector2(-movementspeed, rigidbody2D.velocity.y);
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                rigidbody2D.velocity = new Vector2(+movementspeed, rigidbody2D.velocity.y);
            }
            else // no keys pressed 
            {
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        }
    }

    private bool IsGrounded()
    {


        RaycastHit2D raycastHit2D = Physics2D.BoxCast(spriteRenderer.bounds.center,
            spriteRenderer.bounds.size, 0f, 
            Vector2.down, IsGroundedRayLength, platformLayerMask);
         return raycastHit2D.collider != null;
    }


    private void SetCharacterState()
    {
        if (IsGrounded())
        {
            if (rigidbody2D.velocity.x == 0)
            {
                characterMovementState = MovementStates.idle;
            }
            else if (rigidbody2D.velocity.x > 0)
            {
                facingDirection = FacingDirection.Right;
                characterMovementState = MovementStates.running;
            }
        }
        else if (rigidbody2D.velocity.x < 0)
        {
            facingDirection = FacingDirection.left;
            characterMovementState = MovementStates.running;
        }
    }   

    private void PlayAnimationsBasedOnState()
    {
        switch (characterMovementState)
        {
            case MovementStates.idle:
                animator.SetBool("isrunning", false);
                animator.SetBool("isjumping", false);
                break;
            case MovementStates.running:
                animator.SetBool("isrunning", true);
                animator.SetBool("isjumping", false);
                break;
            case MovementStates.jumping:   
                animator.SetBool("isjumping", true);
                break;
            case MovementStates.attacking:
                break;
            default:
                break;
        }
    }
}
