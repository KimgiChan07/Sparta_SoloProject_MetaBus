using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public enum UIState
{
    FlappyBird,
    TheStack,
    Secret,
    Warp
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

        for (int i = 0; i < eventUIs.Length; i++)
        {
            if (eventUIs[i] == null)
            {
                continue;
            }

            eventUIs[i].Init(this);
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
        ImageManager.instance.SetState(state);
    }

    public void HideUI(UIState state)
    {
        int index = (int)state;

        if (index >= 0 && index < eventUIs.Length && eventUIs[index] != null)
        {
            if (eventUIs[index].gameObject != null)
                eventUIs[index].SetUIHide();
        }

        if (ImageManager.instance != null)
        {
            ImageManager.instance.StopImagesView();
        }
    }

    public void UIAllHide()
    {
        for (int i = 0; i < eventUIs.Length; i++)
        {
            eventUIs[i].SetUIHide();
        }
    }
}
