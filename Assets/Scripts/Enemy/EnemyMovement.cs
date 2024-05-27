using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    
    public void Move(Vector3 movePosition)
    {
        if(!_agent) return;

        _agent.SetDestination(movePosition);
    }
}
