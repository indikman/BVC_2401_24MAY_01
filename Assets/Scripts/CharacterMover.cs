using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMover : MonoBehaviour
{

    private PlanePointDetector _planePointDetector;
    private NavMeshAgent _navMeshAgent;
    void Start()
    {
        _planePointDetector = FindObjectOfType<PlanePointDetector>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
        if(!_planePointDetector || !_navMeshAgent) return;

        _planePointDetector.OnPointDetected += OnPointDetected;
    }

    private void OnPointDetected(Vector3 location)
    {
        _navMeshAgent.SetDestination(location);
    }

    
}
