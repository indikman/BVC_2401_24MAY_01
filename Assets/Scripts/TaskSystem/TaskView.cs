using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace indika.programmingclass
{
    public class TaskView : MonoBehaviour
    {
        [SerializeField] private TMP_Text tasksCompleted;        
        [SerializeField] private TMP_Text tasksAvailable;

        [SerializeField] private Task[] tasks;

        private void OnEnable()
        {
            foreach (var task in tasks)
            {
                tasksAvailable.text += $"\n [ ] {task.name}";
                task.OnTaskFulfilled += TaskFulfilled;
            }
        }

        void TaskFulfilled(Task task)
        {
            tasksCompleted.text += $"\n [x] {task.name}";
        }
    }
}
