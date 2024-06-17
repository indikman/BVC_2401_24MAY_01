using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace indika.programmingclass
{
    public class TaskUpdater : MonoBehaviour
    {
        [SerializeField] private Task customTriggerTask;

        private void OnTriggerEnter(Collider other)
        {
            if(customTriggerTask.isTaskFulfilled) return;

            if (customTriggerTask.type == TaskType.COLLISION_TRIGGER)
            {
                if (other.CompareTag("Player"))
                {
                    customTriggerTask.FulfillTask();
                }
            }
        }
    }
}
