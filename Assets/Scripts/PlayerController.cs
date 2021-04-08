using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    public float horizontal;
    public float speed;
    public float jump;
    public float jumpForce;

    public bool facingRight = true;
    public bool grounded;

    public LayerMask whatIsGround;
    public float groundRadius;
    public Transform groundPoint;

    Rigidbody2D rB;
    Animator animation;

    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        jump= Input.GetAxisRaw("Jump");

    }
    private void FixedUpdate()
    {
        Flip();
        grounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, whatIsGround);
        Move();
        Jump();
        animation.SetFloat("Speed", Mathf.Abs(rB.velocity.x));
        animation.SetBool("Grounded", grounded);
        animation.SetFloat("vSpeed", rB.velocity.y);

    }
    void Move()
    {
        rB.velocity = new Vector2(horizontal * speed, rB.velocity.y);

    }
    void Jump()
    {   
        if(grounded)
        rB.velocity = new Vector2(rB.velocity.x, jump * jumpForce);
    }
    void Flip()
    {
        if (horizontal < 0 && facingRight == true || (horizontal > 0 && facingRight ==false)) 
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
