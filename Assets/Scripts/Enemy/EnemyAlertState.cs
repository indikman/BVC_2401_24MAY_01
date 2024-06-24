using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.indiprogramming.interfaces;
using indika.programmingclass;

public class EnemyAlertState : IState
{
    private EnemyStateMachine _stateMachine;
    private Timer _alertTimer;
    
    public EnemyAlertState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _alertTimer = new Timer();
    }

    public void EnterState()
    {
        Debug.Log("I am now in Alert!!!");
        _stateMachine.toolTip.SetTooltipText("HEY!!!");
        
        _alertTimer.StartTimer(1.0f);
        _alertTimer.onTimerEnd += StartFollow;
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        _alertTimer.UpdateTimer();
    }

    private void StartFollow()
    {
        _alertTimer.onTimerEnd -= StartFollow;
        _stateMachine.SetState(_stateMachine.followState);
    }
}
