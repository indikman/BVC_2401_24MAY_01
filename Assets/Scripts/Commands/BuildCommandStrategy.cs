using UnityEngine;
using UnityEngine.AI;
using com.indiprogramming.interfaces;

public class BuildCommandStrategy : ICommandStrategy
{
    private Builder _builder;
    private NavMeshAgent _agent;

    public BuildCommandStrategy(NavMeshAgent agent, Builder builder)
    {
        _agent = agent;
        _builder = builder;
    }
    
    public Command CreateCommand(Vector3 position)
    {
        return new BuildCommand(_agent, _builder, position);
    }
}