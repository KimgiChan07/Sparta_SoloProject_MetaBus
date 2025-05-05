using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField]private PlayerInput  playerInput;
    // Start is called before the first frame update


    public void SwitchCurrentActionMap()
    {
        playerInput.SwitchCurrentActionMap("PlayerControls");
    }
    public void SwitchToImageControls()
    {
        playerInput.SwitchCurrentActionMap("ImageControls");
    }
}
