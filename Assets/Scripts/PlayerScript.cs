using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    Animator animation;



    public Stats playerStats = new Stats();
    public int arrowDamage;

    void OnCollisionEnter2D(Collision2D other )
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            DamagePlayer(arrowDamage);
            Destroy(other.gameObject);
            
            
        }
    }
   
    void Start()
    {
        playerStats.SetHealth();
        animation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void FixedUpdate()
    {
       
    }


        public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        animation.SetTrigger("isHit");

        if (playerStats.Health <= 0)
        {
            Destroy(gameObject);
            GameManager.GM.StartCoroutine(GameManager.GM.Respawn());
        }
    }
}
