using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollierDebug : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("충돌 타겟: " + other.collider.name);
        
        Bounds bounds = other.collider.bounds;
        Debug.Log($"Bounds Center: {bounds.center}, Bounds Extents: {bounds.extents},  Bounds Size: {bounds.size}");
    }
}
