using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCommand : Command
{
    private NavMeshAgent _agent;
    private Vector3 _destination;

    public MoveCommand(NavMeshAgent agent, Vector3 destination)
    {
        _agent = agent;
        _destination = destination;
    }
    
    public override void Execute()
    {
        _agent.SetDestination(_destination);
    }

    public override bool IsComplete => ReachedDestination();
    
    bool ReachedDestination()
    {
        return _agent.remainingDistance <= 0.05f;
    }
}
