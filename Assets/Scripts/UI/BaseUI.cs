using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager _uiManager)
    {
        this.uiManager=_uiManager;
    }

    protected abstract UIState getUIState();

    public void SetActive(UIState _uiState)
    {
        this.gameObject.SetActive(getUIState()==_uiState);
    }

}
