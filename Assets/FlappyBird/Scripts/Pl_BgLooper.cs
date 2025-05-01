using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_BgLooper : MonoBehaviour
{
    public int obstacleCount=0;
    public Vector3 obstacleLastPos=Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        Pl_Obstacle[] obstacles = FindObjectsOfType<Pl_Obstacle>();
        obstacleLastPos= obstacles[0].transform.position;
        obstacleCount=  obstacles.Length;
        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPos = obstacles[i].SetRandomPlace(obstacleLastPos, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered: "+other.name);;
        Pl_Obstacle plObstacle=other.GetComponent<Pl_Obstacle>();

        if (plObstacle)
        {
            obstacleLastPos=plObstacle.SetRandomPlace(obstacleLastPos, obstacleCount);
        }
    }
}
