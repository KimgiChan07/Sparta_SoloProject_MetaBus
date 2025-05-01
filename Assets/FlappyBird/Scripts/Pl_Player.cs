using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pl_Player : MonoBehaviour
{
    private static readonly int IsDie = Animator.StringToHash("isDie");
    private Animator animator;
    private Rigidbody2D _rigidbody2D;

    public float flapFroce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    public float deathCooldown;
    public bool isFlap = false;

    public bool godMode = false;
    
    Pl_GameManager _plGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _plGameManager = Pl_GameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody2D=  GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("No animator found");
        }

        if (_rigidbody2D == null)
        {
            Debug.LogError("No rigidbody found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
                {
                   _plGameManager.Restart();
                }
            }
            else
            {
                deathCooldown-= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if(isDead) return;
        
        Vector3 velocity = _rigidbody2D.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapFroce;
            isFlap = false;
        }
        _rigidbody2D.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody2D.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(godMode) return;
        if(isDead) return;

        isDead = true;
        deathCooldown = 1f;
        animator.SetInteger(IsDie,1);
        
        _plGameManager.GameOver();
    }
}
