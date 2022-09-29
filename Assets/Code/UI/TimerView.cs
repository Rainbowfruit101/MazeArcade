using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TimerView: MonoBehaviour
    {
        [SerializeField] private TimerController controller;
        [SerializeField] private TMP_Text valuePlace;

        [SerializeField] private Button start;
        [SerializeField] private Button pause;
        [SerializeField] private Button reset;

        private void Awake()
        {
            controller.OnTimerEnded += TimerEnded;
            controller.OnTimerTick += TimerTick;
            start.onClick.AddListener(controller.StartTimer);
            pause.onClick.AddListener(controller.PauseTimer);
            reset.onClick.AddListener(controller.ResetTimer);
        }

        private void OnDestroy()
        {
            controller.OnTimerEnded -= TimerEnded;
            controller.OnTimerTick -= TimerTick;
        }

        private void Start()
        {
            valuePlace.text = controller.Value.ToString();
        }

        private void TimerTick(int value)
        {
            valuePlace.text = value.ToString();
        }

        private void TimerEnded()
        {
            valuePlace.color = Color.cyan;
        }
    }
}