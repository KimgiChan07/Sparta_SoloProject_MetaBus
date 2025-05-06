using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowCamera : MonoBehaviour
{
    [System.Serializable]
    public class CameraArea
    {
        [SerializeField] private string areaName;
        [SerializeField] private Rect bounds;

        public Rect Bounds => bounds;
        public Vector2 center => bounds.center;
        public Vector2 mapSize => bounds.size;
    }

    [SerializeField] private List<CameraArea> cameraAreas;

    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 cameraPosition;

    [SerializeField] private float cameraMoveSpeed;

    private float width;
    private float height;
    private CameraArea currentArea;

    void Start()
    {
        if (cameraTarget == null)
            cameraTarget = GameObject.Find("Player").GetComponent<Transform>();
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    void FixedUpdate()
    {
        currentArea = GetCurrentArea();
        CameraLimitArea();
    }

    CameraArea GetCurrentArea()
    {
        foreach (var area in cameraAreas)
        {
            if (area.Bounds.Contains(cameraTarget.position))
                return area;
        }

        return null;
    }

    void CameraLimitArea()
    {
        if(cameraTarget == null)return;
        
        transform.position = Vector3.Lerp(transform.position,
            cameraTarget.position + cameraPosition,
            cameraMoveSpeed * Time.deltaTime);
        float clampX = Mathf.Clamp(transform.position.x,
            currentArea.Bounds.xMin+width,
            currentArea.Bounds.xMax-width);
        float clampY = Mathf.Clamp(transform.position.y,
            currentArea.Bounds.yMin+height,
            currentArea.Bounds.yMax-height);

        transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (cameraTarget != null)
        {
            foreach (var area in cameraAreas)
            {
                Gizmos.DrawWireCube(area.center, area.mapSize);
            }   
        }
    }
}