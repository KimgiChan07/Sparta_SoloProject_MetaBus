using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUI : MonoBehaviour
{
    
    protected UIManager uiManager;

    public virtual void Init(UIManager _uiManager)
    {
        uiManager = _uiManager;
    }
    public virtual void SetUIShow()
    {
        gameObject.SetActive(true);
    }

    public virtual void SetUIHide()
    {
        gameObject.SetActive(false);
    }

}
