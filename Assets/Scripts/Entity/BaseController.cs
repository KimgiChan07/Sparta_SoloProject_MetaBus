using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer playerRenderer;
    
    protected Vector2 moveDir= Vector2.zero;
    public Vector2 MoveDir{get{return moveDir;}}

    protected Vector2 lookDir=Vector2.zero;
    public Vector2 LookDir{get{return lookDir;}}
    
    protected AnimationHandler animationHandler;
    protected StatHandler statHandler;


    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
        statHandler = GetComponent<StatHandler>();
    }

    protected virtual void Update()
    {
        HandlerAction();
        Rotate(lookDir);
    }

    protected virtual void FixedUpdate()
    {
        Movement(moveDir);
    }

    protected virtual void HandlerAction()
    {
        
    }

    private void Movement(Vector2 _dir)
    {
        _dir = _dir * statHandler.Speed;
        rigidbody.velocity = _dir;
        animationHandler.Move(_dir);
    }

    private void Rotate(Vector2 _dir)
    {
        float rotZ = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;
        
        playerRenderer.flipX = isLeft;

    }
}
