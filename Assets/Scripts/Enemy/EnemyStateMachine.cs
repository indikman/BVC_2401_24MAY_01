using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.indiprogramming.interfaces;

public class EnemyStateMachine : MonoBehaviour
{
    private IState _currentState;

    /// <summary>
    /// STATES
    /// </summary>
    public EnemyPatrolState patrolState { get; private set; }
    public EnemyAlertState alertState { get; private set; }
    public EnemyFollowState followState { get; private set; }
    
    
    public EnemyMovement enemyMovemet { get; private set; }
    public EnemyThreatDetector enemyThreatDetector  { get; private set; }
    public Tooltip toolTip { get; private set; }
    
    
    public GameObject CurrentThreat { get; set; }

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
        followState = new EnemyFollowState(this);

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
