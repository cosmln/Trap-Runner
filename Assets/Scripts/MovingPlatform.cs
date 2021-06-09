using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{ 
    public Transform[] point;
    public int startingPoint;
    public int targetPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = point[startingPoint].position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, point[targetPoint].position, speed * Time.deltaTime);
        if (gameObject.transform.position.x == point[targetPoint].position.x && gameObject.transform.position.y == point[targetPoint].position.y)
        {
            targetPoint++;
            if(targetPoint==point.Length)
            {
                targetPoint = 0;
            }
        }
    }
}
