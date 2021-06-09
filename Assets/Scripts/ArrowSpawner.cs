using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public ArrowScript arrowPrefab;
    public float arrowSpeed;
    public float time = 0;
    public float arrowDelay;

    public bool fromLeft = false;
    public bool shoot;

    private Vector2 dir2;
    // Start is called before the first frame update
    void Start()
    {
        dir2 = new Vector2(arrowSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(shoot == true)
        {
            if(time < Time.time)
            {
                ArrowScript arrow = Instantiate(arrowPrefab, transform.position, transform.rotation) as ArrowScript;
                arrow.dir = dir2;
                if(fromLeft==true)
                {
                    arrow.transform.rotation = Quaternion.Euler(0,0,180);
                }
                else
                {
                    arrow.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                time = Time.time + arrowDelay;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            shoot = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"));
        {
            shoot = false;
        }
    }
}
