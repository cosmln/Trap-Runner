using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject prefab;
    private GameObject respawnPoint;
    public GameObject gameover;
    public GameObject finishlevel;



    void Awake()
    {
        if (GM==null)
        {
            GM = this;
        }
        else
        {
            Destroy(gameObject);
            
        }
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn");

    }

    public IEnumerator Respawn()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(prefab, respawnPoint.transform.position, respawnPoint.transform.rotation );
    }

    public void Retry()
    {
 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Die()
    {
        gameover.SetActive(true);

    }
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);

    }
    public void FinishLevel()
    {

        finishlevel.SetActive(true);

    }


}
