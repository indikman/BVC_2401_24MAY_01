using UnityEngine;
using UnityEngine.AI;
using com.indiprogramming.interfaces;

public class MoveCommandStrategy : ICommandStrategy
{
    private NavMeshAgent _agent;
    public MoveCommandStrategy(NavMeshAgent agent)
    {
        _agent = agent;
    }
    
    public Command CreateCommand(Vector3 position)
    {
        return new MoveCommand(_agent, position);
    }
}
