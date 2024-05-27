using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerReticle : MonoBehaviour
{
    private PlanePointDetector _planePointDetector;
    private const float FAR_AWAY = 10000;
    void Start()
    {
        MoveFar();
        
        _planePointDetector = FindObjectOfType<PlanePointDetector>();
        
        if(!_planePointDetector) return;

        _planePointDetector.OnPointDetected += OnPointDetected;
    }

    private void OnPointDetected(Vector3 point)
    {
        transform.position = point;
        Invoke(nameof(MoveFar), 4f);
    }

    void MoveFar()
    {
        transform.position = Vector3.one * FAR_AWAY;
    }
}
