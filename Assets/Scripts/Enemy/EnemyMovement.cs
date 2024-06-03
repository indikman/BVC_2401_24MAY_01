using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private bool _isPatrolling;
    private bool _isAtDestination;

    [SerializeField] private Transform[] patrolPoints;

    private int _currentPatrolIndex;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _isAtDestination = false;
        _currentPatrolIndex = 0;
    }
    
    public void Move(Vector3 movePosition)
    {
        if(!_agent) return;

        _agent.SetDestination(movePosition);
    }

    public void SetPatrolling(bool active)
    {
        _isPatrolling = active;

        if (!_isPatrolling) _agent.SetDestination(_agent.transform.position);
    }

    private void Update()
    {
        UpdateReachDestination();
        CheckAndPatrol();
    }

    private void CheckAndPatrol()
    {
        if(!_isPatrolling) return;
        
        if(patrolPoints.Length < 1) return;

        if (_isAtDestination)
        {
            if (_currentPatrolIndex == patrolPoints.Length - 1)
            {
                _currentPatrolIndex = 0;
            }
            else
            {
                _currentPatrolIndex++;
            }
            
            Move(patrolPoints[_currentPatrolIndex].position);
        }
    }

    private void UpdateReachDestination()
    {
        _isAtDestination = _agent.remainingDistance <= 0.05f;
    }
}
