using UnityEngine;
using System;

namespace indika.programmingclass
{
    public class Timer
    {
        public event Action onTimerStart;
        public event Action onTimerEnd;
        public event Action<float> onTimerUpdate;

        private float _currentTimerValue;
        private bool _isRunning;
        
        public void StartTimer(float timerValue)
        {
            _currentTimerValue = timerValue;
            _isRunning = true;
            onTimerStart?.Invoke();
        }

        public void StopTimer()
        {
            _isRunning = false;
            onTimerEnd?.Invoke();
        }

        /// <summary>
        /// This needs to be executed within an update method
        /// </summary>
        public void UpdateTimer()
        {
            if(!_isRunning) return;

            _currentTimerValue -= Time.deltaTime;
            onTimerUpdate?.Invoke(_currentTimerValue);

            if (_currentTimerValue <= 0)
            {
                StopTimer();
            }
        }
    }
}
