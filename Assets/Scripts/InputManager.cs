using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputManager : MonoBehaviour
{
    // Player will listen to this
    public event Action<Vector2> onMove;

    private void OnEnable()
    {
        SetupInputs();
    }
    
    private void SetupInputs()
    {
        PlayerInput playerInput = new PlayerInput();

        playerInput.Player.Move.performed += OnMove;
        
        playerInput.Enable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }
}
