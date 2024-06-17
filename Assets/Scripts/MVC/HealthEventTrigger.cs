using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace indika.programmingclass.MVC
{
    public class HealthEventTrigger : MonoBehaviour
    {
        [SerializeField] private Health health;

        public UnityEvent OnHealthUpdatedDefault;
        public UnityEvent<string> OnHealthUpdatedTextValue;
        
        private void OnEnable()
        {
            health.OnHealthUpdated += UpdateHealthView;
        }

        private void OnDisable()
        {
            health.OnHealthUpdated -= UpdateHealthView;
        }

        private void UpdateHealthView(int currentHealth, int maxHealth)
        {
            OnHealthUpdatedDefault?.Invoke();
            OnHealthUpdatedTextValue?.Invoke((currentHealth-maxHealth).ToString());
        }
    }
}
