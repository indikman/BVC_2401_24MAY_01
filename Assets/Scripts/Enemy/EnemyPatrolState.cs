using UnityEngine;

public class EnemyPatrolState : IState
{
    private EnemyStateMachine _stateMachine;
    public EnemyPatrolState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    
    public void EnterState()
    {
        Debug.Log("I am now patrolling!");
        // Start patrolling
        _stateMachine.enemyMovemet.SetPatrolling(true);
        
        //Be in the lookout for the player
        _stateMachine.enemyThreatDetector.StartDetecting("Player", 2, 0.5f);
        _stateMachine.enemyThreatDetector.onThreatDetected += ThreatDetected;

        _stateMachine.toolTip.SetTooltipText("Minding my business!");
    }

    public void ExitState()
    {
        Debug.Log("I am stopping the patrolling state");
        //Stop patrolling
        _stateMachine.enemyMovemet.SetPatrolling(false);
        
        //Stop looking for threats for a moment
        _stateMachine.enemyThreatDetector.StopDetecting();
        _stateMachine.enemyThreatDetector.onThreatDetected -= ThreatDetected;
    }

    public void UpdateState()
    {
        
    }

    private void ThreatDetected(GameObject threat)
    {
        Debug.Log("Oh, I saw an enemy!! I am now switching to Alert!!!!");
        _stateMachine.SetState(_stateMachine.alertState);
    }
}
