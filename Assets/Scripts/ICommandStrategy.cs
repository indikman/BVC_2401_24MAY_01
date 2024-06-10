using UnityEngine;

public interface ICommandStrategy
{
    Command CreateCommand(Vector3 position);
}