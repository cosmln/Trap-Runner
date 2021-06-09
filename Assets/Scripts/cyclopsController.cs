using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cyclopsController : MonoBehaviour
{

    public Transform originPoint;
    private Vector2 dir = new Vector2(1, 0);

    public float range;
    public float speed;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(originPoint.position, dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        if(hit == true)
        {
            if(hit.collider.CompareTag("Ground"))
            {
                Flip();
                speed *= -1;
                dir *= -1;
            }
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
