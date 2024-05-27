using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IState _currentState;

    public EnemyPatrolState patrolState;
    public EnemyAlertState alertState;

    public void SetState(IState newState)
    {
        _currentState?.ExitState();
        _currentState = newState;
        _currentState.EnterState();
    }

    private void Awake()
    {
        patrolState = new EnemyPatrolState(this);
        alertState = new EnemyAlertState(this);
        
        //Set Default state
        SetState(patrolState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
}
