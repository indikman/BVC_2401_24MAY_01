using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace indika.programmingclass
{
    [CreateAssetMenu(fileName = "Task", menuName = "Indika/Task")]
    public class Task : ScriptableObject
    {
        public string name;
        public string description;
        public bool isTaskFulfilled;
        public TaskType type;

        public event Action<Task> OnTaskFulfilled;

        public void FulfillTask()
        {
            isTaskFulfilled = true;
            OnTaskFulfilled?.Invoke(this);
        }
    }

    [Serializable]
    public enum TaskType
    {
        CLICK,
        COLLISION_TRIGGER
    }
}
