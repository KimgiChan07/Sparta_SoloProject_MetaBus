using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    private GameManager _gameManager;

    public void Init(GameManager gameManager)
    {
        this._gameManager = gameManager;
        camera = Camera.main;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerPosX"))
        {
            float posX = PlayerPrefs.GetFloat("PlayerPosX");
            float posY = PlayerPrefs.GetFloat("PlayerPosY");
            float posZ = PlayerPrefs.GetFloat("PlayerPosZ");
            transform.position = new Vector3(posX, posY, posZ);
        }
    }

    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>();
        moveDir = moveDir.normalized;
    }


    void OnLook(InputValue value)
    {
        if (!animationHandler.animator.GetBool("IsSleeping"))
        {
            Vector2 mousePos = value.Get<Vector2>();
            Vector2 worldPos = camera.ScreenToWorldPoint(mousePos);
            lookDir = (worldPos - (Vector2)transform.position);

            if (lookDir.magnitude < .9f)
            {
                lookDir = Vector2.zero;
            }
            else
            {
                lookDir = lookDir.normalized;
            }
        }
    }
}