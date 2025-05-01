using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public UIState targetState;
    public UIManager uIManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uIManager.SetState(targetState);
        }
    }
}
