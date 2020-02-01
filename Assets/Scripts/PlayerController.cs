using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public int level = 0;
    public float maxSpeed = 3;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool idle = false;

    [SerializeField]
    float uprightCorrection;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded && level > 1)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x < 0.00f) : (move.x > 0.01f));
        if (flipSprite)
        {
            //spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        animator.SetBool("grounded", grounded);
        animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        if (move.x < 0 && targetVelocity.magnitude > 0.01f)
        {
            animator.Play("p1_player_move_right");
            idle = false;
        } else if (move.x > 0 && targetVelocity.magnitude > 0.01f)
        {
            animator.Play("p1_player_move_left");
            
            idle = false;
        } else
        {
            if (!idle)
            {
                animator.Play("p1_player_idle");
                idle = true;
            }
        }

        void levelUp()
        {
            ++level;
            if (level > 1)
            {
                maxSpeed = 7;
            }
        }
    }
}
