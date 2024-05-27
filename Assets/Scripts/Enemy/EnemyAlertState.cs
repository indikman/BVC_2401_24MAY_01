using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertState : IState
{
    private EnemyStateMachine _stateMachine;

    public EnemyAlertState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void EnterState()
    {
        Debug.Log("I am now in Alert!!!");
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        
    }
}
