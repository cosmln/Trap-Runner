using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//using System.Threading;
//using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    public GameObject bulletRef;
    //bool isGrounded;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    private LayerMask platformLayerMask;// = new LayerMask();

    [SerializeField]
    private float runSpeed = 4.5f;

    [SerializeField]
    private float jumpSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        platformLayerMask = GetComponent<LayerMask>();
        groundCheck = GetComponent<Transform>();
    
        bulletRef = Resources.Load<GameObject>("Bullet");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletRef);
            bullet.transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y + .2f, -1f);
        }

        if (!isGrounded())
        {
            animator.Play("player_jump");
        }

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = false;
            /*
            if (isGrounded())
            {
                rb2d.velocity = new Vector2(2, rb2d.velocity.y);
                animator.Play("player_run");
                spriteRenderer.flipX = false;
            }
            */
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            animator.Play("player_run");
            spriteRenderer.flipX = true;
            /*
            //if (isGrounded())
            if (isGrounded())
            {
                rb2d.velocity = new Vector2(-2, rb2d.velocity.y);
                animator.Play("player_run");
                spriteRenderer.flipX = true;
            }
            */
        }
        else {
            if (isGrounded())
            {
                animator.Play("Idle");
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            }
        }
        

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            if (rb2d.velocity.y != 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - 3);
                animator.Play("player_tuck");
            }
        }

        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            animator.Play("player_jump");
            /*
            if (isGrounded())
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
                animator.Play("player_jump");
            } */
        }

        if (Input.GetKey("space"))
        {
            //Debug.Log("SPACE! -> ");
            //RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, playerYSize / 2);
            //if (isGrounded()) {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed * 5);
            animator.Play("player_jump");
            //}
            
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = .05f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText, platformLayerMask);
        Color rayColor;
        
        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        //Debug.Log(raycastHit.collider);
        //Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightText));

        return raycastHit.collider != null;
    }

    private bool isGrounded2()
    {
        float extraHeightText = .05f;
        if (Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText, platformLayerMask))
        {
            return true;
        }
        return false;
    }
}