using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUI : BaseUI
{
    [SerializeField]private Button startButton;
    
    [SerializeField] private int sceneIndex;
    
    public UIState uiState;
    
    private RectTransform[] childPanels;


    public override void Init(UIManager _uiManager)
    {
        base.Init(_uiManager);
        
        startButton.onClick.AddListener(OnClickStartButton);
    }

    private void Awake()
    {
        childPanels = GetComponentsInChildren<RectTransform>(true);
    }

    public void OnClickStartButton()
    {
        Debug.Log("OnClickStartButton");
        GameManager.Instance.MiniGameStart(sceneIndex);
    }

    public override void SetUIShow()
    {
        base.SetUIShow(); 
        SetActive(true);
    }

    public override void SetUIHide()
    {
        SetActive(false);
        base.SetUIHide();
    }

    private void SetActive(bool _isActive)
    {
        if (childPanels == null) return;
        foreach (var child in childPanels)
        {
            if (child != null && child != this.transform && child.gameObject != null)
                child.gameObject.SetActive(_isActive);
        }
    }
}
