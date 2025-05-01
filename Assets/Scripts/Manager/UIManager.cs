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
    EventUI eventUI;
    NpcUI npcUI;
    DesignUI designUI;
    
    public UIState currentState;


    public void SetState(UIState state)
    {
        currentState = state;
        eventUI.SetActive(currentState);
    }
}
