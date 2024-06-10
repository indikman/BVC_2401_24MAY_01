using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildCommand : Command
{
    private NavMeshAgent _agent;
    private Vector3 _destination;
    private Builder _builder;
    private bool _buildingComplete;

    public BuildCommand(NavMeshAgent agent, Builder builder, Vector3 destination)
    {
        _agent = agent;
        _builder = builder;
        _destination = destination;
    }
    
    public override void Execute()
    {
        _agent.SetDestination(_destination);
    }

    public override bool IsComplete => ReachedDestination();
    
    bool ReachedDestination()
    {
        if (_agent.remainingDistance > 0.05f) return false;

        if (!_buildingComplete && _builder != null)
        {
            _builder.Build(_destination, _agent.transform.rotation);
            _buildingComplete = true;
        }
            
        return true;

    }
}
