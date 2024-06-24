using UnityEngine;
using UnityEngine.InputSystem;
using System;

[CreateAssetMenu(menuName = "Indika/InputManager", fileName = "InputManager")]
public class InputManager : ScriptableObject
{
    // Player will listen to this
    public event Action<Vector2> onMove;
    private PlayerInput _playerInput;
    
    private void OnEnable()
    {
        SetupInputs();
    }

    private void OnDisable()
    {
        DisableInputs();
    }

    private void SetupInputs()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Move.performed += OnMove;
        _playerInput.Enable();
    }

    private void DisableInputs()
    {
        if(_playerInput == null) return;
        
        _playerInput.Player.Move.performed -= OnMove;
        _playerInput.Disable();
        _playerInput = null;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        onMove?.Invoke(context.ReadValue<Vector2>());
    }
}
