using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 dir = new Vector2(-10, 0);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = dir;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
           
            Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Platform"))
        {

            Destroy(this.gameObject);
        }
    }
}
