using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;
    
    private GameManager gameManager;

    public void Init(GameManager _gameManager)
    {
        this.gameManager = _gameManager;
        camera = Camera.main;
    }

    void OnMove(InputValue value)
    {
        moveDir=value.Get<Vector2>();
        moveDir = moveDir.normalized;
    }

    void OnLook(InputValue value)
    {
        Vector2 mousePos=value.Get<Vector2>();
        Vector2 worldPos=camera.ScreenToWorldPoint(mousePos);
        lookDir = (worldPos - (Vector2)transform.position);

        if (lookDir.magnitude < .9f)
        {
            lookDir=Vector2.zero;
        }
        else
        {
            lookDir=lookDir.normalized;
        }
    }
}
