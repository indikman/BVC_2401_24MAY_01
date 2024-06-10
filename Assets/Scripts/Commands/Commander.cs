using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Commander : MonoBehaviour
{
    private PlanePointDetector _planePointDetector;
    private NavMeshAgent _navMeshAgent;
    private Builder _builder;

    private Queue<Command> _commands = new Queue<Command>();
    private Command _currentCommand;
    private ICommandStrategy _currentStrategy;

    // Keep all the strategies here!
    private MoveCommandStrategy _moveCommandStrategy;
    private BuildCommandStrategy _buildCommandStrategy;
    
    
    [SerializeField] private TMP_Text txtCurrentStrategy;
    
    void Start()
    {
        _planePointDetector = FindObjectOfType<PlanePointDetector>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _builder = GetComponent<Builder>();
        
        if(!_planePointDetector || !_navMeshAgent) return;

        _moveCommandStrategy = new MoveCommandStrategy(_navMeshAgent);
        _buildCommandStrategy = new BuildCommandStrategy(_navMeshAgent, _builder);

        _planePointDetector.OnPointDetected += OnPointDetected;
    }

    private void OnPointDetected(Vector3 location)
    {
        if(_currentStrategy == null) return;
        
        // create a command and add it to the queue
        _commands.Enqueue(_currentStrategy.CreateCommand(location));
    }

    public void SetMoveStrategy()
    {
        _currentStrategy = _moveCommandStrategy;
        txtCurrentStrategy.text = "Move";
    }
    
    public void SetBuildStrategy()
    {
        _currentStrategy = _buildCommandStrategy;
        txtCurrentStrategy.text = "Build";
    }
    
    private void Update()
    {
        ProcessCommands();
    }

    private void ProcessCommands()
    {
        // If there is a current command and that command is not complete yet, return
        if(_currentCommand != null && !_currentCommand.IsComplete) return;
        
        // If there are no commands, return
        if(_commands.Count == 0) return;

        // grab the first command from the queue and execute it!
        _currentCommand = _commands.Dequeue();
        _currentCommand.Execute();
    }
}
