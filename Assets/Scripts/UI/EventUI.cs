using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUI : BaseUI
{
    
    public UIState uiState;
    
    private RectTransform[] childPanels;

    private void Awake()
    {
        childPanels = GetComponentsInChildren<RectTransform>(true);
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
        foreach (var child in childPanels)
        {
            if(child!=this.transform)
                child.gameObject.SetActive(_isActive);
        }
    }
}
