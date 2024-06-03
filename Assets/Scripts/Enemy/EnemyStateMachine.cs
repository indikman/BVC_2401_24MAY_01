using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private IState _currentState;

    public EnemyPatrolState patrolState { get; private set; }
    public EnemyAlertState alertState { get; private set; }

    public EnemyMovement enemyMovemet { get; private set; }
    public EnemyThreatDetector enemyThreatDetector  { get; private set; }
    public Tooltip toolTip { get; private set; }

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

        enemyMovemet = GetComponent<EnemyMovement>();
        enemyThreatDetector = GetComponent<EnemyThreatDetector>();
        toolTip = GetComponent<Tooltip>();
        
        
        //Set Default state
        SetState(patrolState);
    }

    private void Update()
    {
        _currentState?.UpdateState();
    }
}
