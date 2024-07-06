using System.Collections;
using System.Collections.Generic;
using com.indiprogramming.interfaces;
using UnityEngine;

public class EnemyAttackState : IState
{
    private EnemyStateMachine _stateMachine;

    public EnemyAttackState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void EnterState()
    {
        _stateMachine.toolTip.SetTooltipText("I am attacking you now!!!!");
        _stateMachine.enemyThreatDetector.SetDetection(
            true, 
            _stateMachine.enemyAIParamSO.viewRadiusAttack, 
            _stateMachine.enemyAIParamSO.viewAngleAttack);
    }

    public void ExitState()
    {
        
    }

    public void UpdateState()
    {
        CheckThreatDistance();
    }
    
    private void CheckThreatDistance()
    {
        var distanceToThreat = Vector3.Distance(_stateMachine.CurrentThreat.transform.position,
            _stateMachine.transform.position);

        // if the enemy is away from the player, go to the follow state
        if (distanceToThreat > _stateMachine.enemyAIParamSO.attackDistance)
        {
            // go to the follow state
            _stateMachine.SetState(_stateMachine.followState);
        }
    }
}
