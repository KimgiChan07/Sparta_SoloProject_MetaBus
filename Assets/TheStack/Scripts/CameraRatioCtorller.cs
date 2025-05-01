using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRatioCtorller : MonoBehaviour
{
    [SerializeField]private float targetAspectRatio;

    private void Start()
    {
        AdjustCameraAspectRatio();
    }

    void AdjustCameraAspectRatio()
    {
        Camera camera = GetComponent<Camera>();

        if (camera != null)
        {
            camera.aspect = targetAspectRatio;
        }
    }
}
