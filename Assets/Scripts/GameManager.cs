using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject prefab;
    private GameObject respawnPoint;

   void Awake()
    {
        if (GM==null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
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
}
