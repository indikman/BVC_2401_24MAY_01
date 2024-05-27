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
    }

    public void ExitState()
    {
        Debug.Log("I am stopping the patrolling state");
    }

    public void UpdateState()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Oh, I saw an enemy!! I am now switching to Alert!!!!");
            _stateMachine.SetState(_stateMachine.alertState);
        }
    }
}
