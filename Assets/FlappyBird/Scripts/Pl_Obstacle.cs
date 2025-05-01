using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pl_Obstacle : MonoBehaviour
{
    
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 1f;
    public float holeSizeMax = 3f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding=4f;
Pl_GameManager _plGameManager;

private void Start()
{
    _plGameManager = Pl_GameManager.Instance;
}

public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);
        
        Vector3 placePosition= lastPosition+new Vector3(widthPadding,0);
        placePosition.y= Random.Range(lowPosY, highPosY);
        
        transform.position = placePosition;
        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Pl_Player plPlayer = other.GetComponent<Pl_Player>();
        if(plPlayer != null){
            _plGameManager.AddScore(1);
        }
    }
}
