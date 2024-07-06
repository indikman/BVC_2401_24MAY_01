using System.Collections;
using System.Collections.Generic;
using com.indiprogramming.interfaces;
using indika.programmingclass;
using UnityEngine;

public class EnemyFollowState : IState
{
    private EnemyStateMachine _stateMachine;
    private Timer _cooldownTimer;
    private const float coolDownTime = 5.0f;

    public EnemyFollowState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _cooldownTimer = new Timer();
    }

    public void EnterState()
    {
        if(_stateMachine.CurrentThreat)
            _stateMachine.enemyMovemet.Move(_stateMachine.CurrentThreat.transform.position);
        
        //start the timer
        _cooldownTimer.StartTimer(coolDownTime);
        _cooldownTimer.onTimerEnd += EnemyCoolDown;
        
        // start threat checking again
        _stateMachine.enemyThreatDetector.SetDetection(true);
        _stateMachine.enemyThreatDetector.onThreatDetected += FollowThreat;
        
        _stateMachine.toolTip.SetTooltipText("I am following you!");
    }

    public void ExitState()
    {
        _stateMachine.enemyThreatDetector.onThreatDetected -= FollowThreat;
    }

    public void UpdateState()
    {
        _cooldownTimer.UpdateTimer();
        CheckThreatDistance();
    }

    private void EnemyCoolDown()
    {
        _stateMachine.CurrentThreat = null;
        _stateMachine.enemyMovemet.Move(_stateMachine.transform.position);
        
        _cooldownTimer.onTimerEnd -= EnemyCoolDown;
        
        _stateMachine.SetState(_stateMachine.patrolState);
    }

    private void FollowThreat(GameObject threat)
    {
        _stateMachine.CurrentThreat = threat;
        _cooldownTimer.StartTimer(coolDownTime);
        _stateMachine.enemyMovemet.Move(threat.transform.position);
    }

    private void CheckThreatDistance()
    {
        var distanceToThreat = Vector3.Distance(_stateMachine.CurrentThreat.transform.position,
            _stateMachine.transform.position);

        // if the enemy is close enough to the player, go to the attack state
        if (distanceToThreat <= 2.0f)
        {
            // stop following the player
            _stateMachine.enemyMovemet.Move(_stateMachine.transform.position);
            
            // go to the attack state
            _stateMachine.SetState(_stateMachine.attackState);
        }
    }
}
