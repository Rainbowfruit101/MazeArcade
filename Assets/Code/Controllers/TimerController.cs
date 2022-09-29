using System;
using System.Collections;
using UnityEngine;

namespace Controllers
{
    public class TimerController : MonoBehaviour
    {
        [SerializeField] private int timerValue;

        private int _value;
        private Coroutine _timerCoroutine;
        public event Action OnTimerEnded;
        public event Action<int> OnTimerTick;

        public int Value => _value;

        private void Awake()
        {
            _value = timerValue;
        }

        public void ResetTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }

            _value = timerValue;
        }

        public void StartTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }

            _timerCoroutine = StartCoroutine(TimerCoroutine());
        }

        public void PauseTimer()
        {
            if (_timerCoroutine != null)
            {
                StopCoroutine(_timerCoroutine);
                _timerCoroutine = null;
            }
        }

        private IEnumerator TimerCoroutine()
        {
            while (_value > 0)
            {
                _value -= 1;
                yield return new WaitForSeconds(1f);
                OnTimerTick?.Invoke(_value);
            }

            OnTimerEnded?.Invoke();
        }
    }
}