using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class The_BaseUI : MonoBehaviour
{
    protected The_UIManager  TheUIManager;

    public virtual void Init(The_UIManager theUIManager)
    {
        this.TheUIManager = theUIManager;
    }
    protected abstract The_UIState GetUIState();

    public void SetActive(The_UIState state)
    {
        gameObject.SetActive(GetUIState()==state);
    }
    
}
