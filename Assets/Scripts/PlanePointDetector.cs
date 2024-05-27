using UnityEngine;
using System;

public class PlanePointDetector : MonoBehaviour
{
    [SerializeField] private LayerMask clickMask;
    private Camera _camera;

    public event Action<Vector3> OnPointDetected;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, clickMask))
            {
                OnPointDetected?.Invoke(hit.point);
            }
    }
}
