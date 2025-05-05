using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("IsMove");
    private static readonly int IsSleep= Animator.StringToHash("IsSleep");
    private static readonly int IsSleeping=  Animator.StringToHash("IsSleeping");

    private float playerStopTimer = 0;
    [SerializeField] private float playerSleepTimer = 3f;
    
    private bool isSleepingTriggered = false;
    private bool isMoving = false;

    public Animator animator;
    protected void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 obj)
    {
        isMoving = obj.magnitude > 0.5f;
        animator.SetBool(IsMove, isMoving);

        if (isMoving)
        {
            playerStopTimer = 0;
            if (isSleepingTriggered)
            {
                animator.SetBool(IsSleep, false);
                animator.SetBool(IsSleeping, false);
                isSleepingTriggered = false;
            }
        }
    }

    private void Update()
    {
        if (!isMoving)
        {
            playerStopTimer+=Time.deltaTime;
            if (playerStopTimer >= playerSleepTimer && !isSleepingTriggered)
            {
                Sleep();
            }
        }
        else
        {
            playerStopTimer = 0f;
        }

    }

    public void Sleep()
    {
        animator.SetBool(IsSleep, true);
        StartCoroutine(Sleeping());
        isSleepingTriggered = true;
    }

    private IEnumerator Sleeping()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool(IsSleeping, true);
    }

    public bool IsSleepingAnim()
    {
        if (animator.GetBool(IsSleeping))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
