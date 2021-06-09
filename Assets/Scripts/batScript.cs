using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class batScript : MonoBehaviour
{
    public float speed;
    public Transform target;
    public bool activated = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            activated = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (activated == true && target != null)
        { 
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
