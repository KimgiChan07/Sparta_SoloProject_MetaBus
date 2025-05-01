using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : The_BaseUI
{
    
    Button startButton;
    Button exitButton;
    protected override The_UIState GetUIState()
    {
        return The_UIState.Home;
    }


    public override void Init(The_UIManager theUIManager)
    {
        base.Init(theUIManager);
        
        startButton=transform.Find("StartButton").GetComponent<Button>();
        //exitButton=transform.Find("ExitButton").GetComponent<Button>();
        
        startButton.onClick.AddListener(OnclickstartButton);
        //exitButton.onClick.AddListener(OnclickexitButton);
    }

    void OnclickstartButton()
    {
        TheUIManager.OnClickStart();
    }

    void OnclickexitButton()
    {
        TheUIManager.OnClickExit();
    }
}
