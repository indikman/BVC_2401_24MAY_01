using UnityEngine;

namespace  com.indiprogramming.interfaces
{
    public interface ICommandStrategy
    {
        Command CreateCommand(Vector3 position);
    }
}
