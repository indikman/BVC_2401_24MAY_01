using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.indiprogramming.interfaces;

public class EnemyAlertState : IState
{
    private EnemyStateMachine _stateMachine;

    private float _cooldownTimer;

    private string[] messages = new string[]
    {
        "hey stop!", 
        "I aint gonna hurt ya",
        "stop right there!",
        "I will hurt you"
    };
    

    public EnemyAlertState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public void EnterState()
    {
        Debug.Log("I am now in Alert!!!");
        _stateMachine.toolTip.SetTooltipText("HEY!!!");
        
        _stateMachine.enemyThreatDetector.StartDetecting("Player", 5, 3f);
        _stateMachine.enemyThreatDetector.onThreatDetected += ThreatDetected;

        _cooldownTimer = 0;
        
        

    }

    public void ExitState()
    {
        _stateMachine.enemyThreatDetector.onThreatDetected -= ThreatDetected;
    }

    public void UpdateState()
    {
        _cooldownTimer += Time.deltaTime;
        if (_cooldownTimer >= 5.0f)
        {
            // If the enemy does not see the threat for 5 seconds, go back to patrolling
            _stateMachine.SetState(_stateMachine.patrolState);
        }

      /*  if (_cooldownTimer >= Random.Range(0, 4))
        {
            _stateMachine.toolTip.SetTooltipText(messages[Random.Range(0, messages.Length)]);
        }*/

        // probably change the text once in a while
    }

    private void ThreatDetected(GameObject threat)
    {
        // if the enemy sees a threat, keep chasing
        _cooldownTimer = 0;
        
        _stateMachine.enemyMovemet.Move(threat.transform.position);
    }
}
