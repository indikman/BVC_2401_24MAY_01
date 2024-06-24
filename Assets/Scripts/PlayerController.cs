using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Rigidbody playerRB;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 0.3f;

    private Vector3 _movementDirection;
    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void OnEnable()
    {
        inputManager.onMove += OnMove;
    }

    private void OnDisable()
    {
        inputManager.onMove -= OnMove;
    }

    private void OnMove(Vector2 inputValue)
    {
        _movementDirection = _cameraTransform.forward * inputValue.y + _cameraTransform.right * inputValue.x;
        _movementDirection.Normalize();
        _movementDirection.y = 0;
    }

    private void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        playerRB.velocity = _movementDirection * moveSpeed;
    }

    private void HandleRotation()
    {
        if(_movementDirection == Vector3.zero) return;
        
        Quaternion targetRotation = Quaternion.LookRotation(_movementDirection);
        playerRB.MoveRotation(Quaternion.Lerp(playerRB.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
    }
}
