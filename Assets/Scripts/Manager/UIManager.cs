using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIState
{
    FlappyBird,
    TheStack,
    Secret,
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{get; private set;}
    
    public EventUI[] eventUIs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("UIManager가 인식이 안되었습니다.");
        }
    }

    private void Start()
    {
        UIAllHide();
    }

    public void ShowUI(UIState state)
    {
        int index = (int)state;
        if(index<0||index>=eventUIs.Length)return;

        eventUIs[index].SetUIShow();
    }

    public void HideUI(UIState state)
    {
        int index = (int)state;
        if(index<0||index>=eventUIs.Length)return;
        eventUIs[index].SetUIHide();
    }

    public void UIAllHide()
    {
        for (int i = 0; i < eventUIs.Length; i++)
        {
            eventUIs[i].SetUIHide();
        }
    }
}
