using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScript : MonoBehaviour

   
{

    public float velX= 5f;
    public float vely = 0f;
    Rigidbody2D rb;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Bat"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Ground"))
        {
           
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX, vely);
        Destroy(this.gameObject, 4f);
    }
}
