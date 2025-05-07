using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    public UIState uiState;
    [SerializeField] string playerTag="Player";
    [SerializeField] private List<GameObject> warpObject;

    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            UIManager.Instance.ShowUI(uiState);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            UIManager.Instance.HideUI(uiState);
        }
    }
}