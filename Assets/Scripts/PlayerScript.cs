using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    Animator animation;
    public GameManager gm;


    public Stats playerStats = new Stats();
    public int arrowDamage;
    public int borderDamage;
    public int coinValue;
    public int enemyDamage;
    void OnCollisionEnter2D(Collision2D other )
    {
        if(other.gameObject.CompareTag("Arrow"))
        {
            DamagePlayer(arrowDamage);
            Destroy(other.gameObject);  
        }
        if (other.gameObject.CompareTag("levelBorder"))
        {
            DamagePlayer(borderDamage);
        }
        if (other.gameObject.CompareTag("Platform"))
        {
            if (transform.position.y > other.transform.position.y)
            { transform.SetParent(other.transform); }
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer(enemyDamage);
            
        }
        if (other.gameObject.CompareTag("Bat"))
        {
            DamagePlayer(arrowDamage);
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("hearth"))
        {
            DamagePlayer(-1);
            Destroy(other.gameObject);

        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gm.FinishLevel();
        }
        if (collision.gameObject.CompareTag("coin"))
        {
            Destroy(collision.gameObject);
            ScoreManager.instance.ChangeScore(Random.Range(1, 6));
        }

    }


    void Start()
    {
        playerStats.SetHealth();
        animation = GetComponent<Animator>();
       
}


        public void DamagePlayer(int damage)
    {
        playerStats.Health -= damage;
        animation.SetTrigger("isHit");

        if (playerStats.Health <= 0)
        {
            animation.SetBool("isDead", true);
            gm.Die();
            Destroy(gameObject);
           
        }
    }
 
}
